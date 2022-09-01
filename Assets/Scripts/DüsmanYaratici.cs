using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DüsmanYaratici : MonoBehaviour
{
    public static DüsmanYaratici instance;

    private void Awake()
    {
        instance = this;
    }

    public DusmanKontrol dogacakDusmanTipi;
    public Transform dogusNoktasi;
    public float beklemeSuresi;
    private float beklemeSayaci;
    public int dogacakDusmanSayisi = 10;
    public float yeniDüsmanCani;
    public float yeniDüsmanHizi;
    public float yeniDüsmanGücü;

    void Start()
    {
        dogacakDusmanTipi.GetComponent<DusmanKontrol>().maksimumCan = yeniDüsmanCani;
        dogacakDusmanTipi.GetComponent<DusmanKontrol>().anlikCan = yeniDüsmanCani;
        dogacakDusmanTipi.GetComponent<DusmanKontrol>().hareketHizi = yeniDüsmanHizi;
        beklemeSayaci = 0;
    }

    void Update()
    {
        beklemeSayaci -= Time.deltaTime;
        if (beklemeSayaci <= 0 && dogacakDusmanSayisi > 0 && SeviyeYonetimi.instance.seviyeAktif)
        {
            beklemeSayaci = beklemeSuresi;

            Instantiate(dogacakDusmanTipi, dogusNoktasi.position, dogusNoktasi.rotation);

            dogacakDusmanSayisi--;
        }
    }
}
