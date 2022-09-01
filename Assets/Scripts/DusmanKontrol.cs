using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DusmanKontrol : MonoBehaviour
{
    public float hareketHizi;

    private IzlenecekYol izlenecekYol;
    private int hedefNokta;
    private bool hedefeUlasildi;

    public float saldiriHizi;
    public float saldiriGucu;
    private float saldiriSayaci;

    private Hedef saldiriHedefi;

    public float maksimumCan = 10f;
    [HideInInspector] public float anlikCan;

    public Slider canBari;

    private void Awake()
    {
        izlenecekYol = FindObjectOfType<IzlenecekYol>();
        saldiriHedefi = FindObjectOfType<Hedef>();
        
        anlikCan = maksimumCan;
        canBari.maxValue = maksimumCan;
        canBari.gameObject.SetActive(false);
    }

    private void Start()
    {
        izlenecekYol = FindObjectOfType<IzlenecekYol>();
        saldiriHedefi = FindObjectOfType<Hedef>();
        
        canBari.value = anlikCan;
        saldiriHizi = saldiriSayaci;
        saldiriHizi = 1f;
        
        SeviyeYonetimi.instance.canliDusmanlar.Add(this);
    }

    private void Update()
    {
        if(SeviyeYonetimi.instance.seviyeAktif){
            if (hedefeUlasildi == false)
            {
                transform.LookAt(izlenecekYol.hedefNoktalari[hedefNokta]);

                transform.position = Vector3.MoveTowards(transform.position,
                    izlenecekYol.hedefNoktalari[hedefNokta].position, hareketHizi * Time.deltaTime);

                //hedef noktaya ulasildiysa, bir sonraki hedef noktaya gec
                if (Vector3.Distance(transform.position, izlenecekYol.hedefNoktalari[hedefNokta].position) < .05f)
                {
                    hedefNokta += 1;
                    if (hedefNokta >= izlenecekYol.hedefNoktalari.Length)
                    {
                        hedefeUlasildi = true;
                    }
                }
            }
            else
            {
                saldiriSayaci -= Time.deltaTime;
                if (saldiriSayaci <= 0)
                {
                    saldiriSayaci = saldiriHizi;
                    saldiriHedefi.HasarVur(saldiriGucu);
                }
            }
        }
    }

    public void HasarAl(float alinacakHasar)
    {
        anlikCan = anlikCan - alinacakHasar;
        canBari.value = anlikCan;
        canBari.gameObject.SetActive(true);
        if (anlikCan <= 0)
        {
            anlikCan = 0;
            Destroy(gameObject);
            SeviyeYonetimi.instance.canliDusmanlar.Remove(this);
        }
    }
}
