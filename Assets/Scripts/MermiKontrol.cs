using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKontrol : MonoBehaviour
{
    public GameObject mermi;
    public Transform atesNoktasi;
    public Transform atesYonu;
    public float saldiriBeklemeSuresi;
    private float saldiriSayaci;
    public Animator anim;

    private void Awake()
    {
        anim.SetBool("Saldir", false);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(SeviyeYonetimi.instance.seviyeAktif){
            saldiriSayaci -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (saldiriSayaci <= 0)
                {
                    saldiriSayaci = saldiriBeklemeSuresi;
                    anim.SetBool("Saldir", true);
                    Instantiate(mermi, atesNoktasi.position, atesYonu.rotation);
                }

                anim.SetBool("Saldir", false);
            }
        }
    }
}
