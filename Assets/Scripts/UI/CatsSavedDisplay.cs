using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatsSavedDisplay : MonoBehaviour
{
    public Text catSavedText;
    public CatSavedCounter cats;

    void Start()
    {
    }

    private void Update()
    {
        catSavedText.text = cats.catsSaved.ToString();
    }

}
