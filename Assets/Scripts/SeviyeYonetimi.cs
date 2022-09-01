using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeviyeYonetimi : MonoBehaviour
{
    public static SeviyeYonetimi instance;

    void Awake()
    {
        instance = this;
    }
    
    public bool seviyeAktif;
    private bool seviyeBasarili;

    public Hedef hedefRef;

    public List<DusmanKontrol> canliDusmanlar = new List<DusmanKontrol>();

    private AnaMenuYöneticisi _anaMenuYöneticisi;
    private void Start()
    {
        seviyeAktif = true;

//      AnaMenuYöneticisi.instance.yeniOyunSahnesi = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        SeviyeAktifMi();

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (UIKontrol.instance.aktifSahne > 14)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(UIKontrol.instance.aktifSahne + 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    private void SeviyeAktifMi()
    {
        //can 0 ve altına düşerse seviyeyi başarısız yap
        if (hedefRef.anlikCan <= 0)
        {
            seviyeAktif = false;
            seviyeBasarili = false;
            UIKontrol.instance.seviyeBasarisizEkrani.SetActive(true);
        }
        
        //eğer doğacak düşman yoksa ve canlı düşman kalmadıysa seviyeyi başarılı yap
        if(DüsmanYaratici.instance.dogacakDusmanSayisi < 1 && canliDusmanlar.Count < 1)
        {
            seviyeAktif = false;
            seviyeBasarili = true;
            UIKontrol.instance.seviyeBasariliEkrani.SetActive(true);
        }
    }
}
