using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hedef : MonoBehaviour
{
    public static Hedef instance;
    
    public float maksimumCan = 10f;
    [HideInInspector] public float anlikCan;

    public Slider canBari;
    private void Awake()
    {
        instance = this;
        anlikCan = maksimumCan;
    }

    private void Start()
    {
        canBari.maxValue = maksimumCan;
        canBari.value = anlikCan;
    }
    
    public void HasarVur(float alinacakHasar)
    {
        anlikCan -= alinacakHasar;

        if (anlikCan <= 0)
        {
            anlikCan = 0;
            gameObject.SetActive(false);
        }

        canBari.value = anlikCan;
    }
}
