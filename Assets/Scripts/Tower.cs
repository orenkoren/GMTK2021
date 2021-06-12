using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private List<Transform> targets = new List<Transform>();

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    public int maxTargets = 1;
    private float fireCountdown = 0f;


    [Header("Unity Setup")]
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget () {

        if(targets.Count > 0) {

            List<int> targetsToDelete = new List<int>();

            for(int i = 0; i < this.targets.Count; i++) {
                Transform target = this.targets[i];

                if(target == null) {
                    continue;
                }

                float distanceToEnemy = Vector3.Distance(transform.position, target.position);
                if(distanceToEnemy > range) {
                    Hatul hatul = target.GetComponent<Hatul>();
                    hatul.SetIsTargeted(false);
                    this.targets[i] = null;
                }
            }

            this.targets.RemoveAll(target => target == null);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        List<GameObject> enemiesList = enemies.ToList();

        enemiesList.Sort((a, b) => (int)GetDistanceToEnemy(a.transform) - (int)GetDistanceToEnemy(b.transform));

        enemiesList.ForEach(enemy => {
            float distanceToEnemy = GetDistanceToEnemy(enemy.transform);
            Hatul enemyComponent = enemy.GetComponent<Hatul>();
            bool isEnemyTargeted = enemyComponent.GetIsTargeted();
            
            if(distanceToEnemy < range && !isEnemyTargeted && this.targets.Count < maxTargets) {
                enemyComponent.SetIsTargeted(true);
                this.targets.Add(enemy.transform);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        this.targets.RemoveAll(target => target == null);

        if(this.targets.Count <= 0) {
            return;
        }

        Transform nearestEnemy = this.targets[0];

        Vector3 dir = nearestEnemy.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot() {       

        this.targets.ForEach(target => {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if(bullet != null) {
                bullet.Seek(target);
            }

        }); 
    }

    private float GetDistanceToEnemy(Transform enemy) {
        return Vector3.Distance(transform.position,enemy.transform.position);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
