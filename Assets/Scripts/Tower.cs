using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
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

        if(target != null) {
            float distanceToEnemy = Vector3.Distance(transform.position, target.position);
            if(distanceToEnemy > range) {
                Hatul previouseHatul = target.GetComponent<Hatul>();
                previouseHatul.SetIsTargeted(false);
                target = null;
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            Hatul hatul = enemy.GetComponent<Hatul>();

            if(distanceToEnemy < shortestDistance && !hatul.GetIsTargeted()) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
            if(target != null) {
                Hatul previouseHatul = target.GetComponent<Hatul>();
                previouseHatul.SetIsTargeted(false);
            }

            target = nearestEnemy.transform;
            Hatul currentHatul = target.GetComponent<Hatul>();
            currentHatul.SetIsTargeted(true);

        } else {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            return;
        }

        Vector3 dir = target.position - transform.position;
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
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null) {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
