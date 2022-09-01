using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIKontrol : MonoBehaviour
{
    public static UIKontrol instance;

    public int aktifSahne;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private TMP_Text kalanDusman;
    [SerializeField] private TMP_Text bolumIndikatoru;
    [SerializeField] private TMP_Text skor;
    
    public GameObject seviyeBasariliEkrani, seviyeBasarisizEkrani;

    private void Start()
    {
        aktifSahne = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        kalanDusman.text = "Kalan Düşman Sayısı: " +
                           (DüsmanYaratici.instance.dogacakDusmanSayisi + SeviyeYonetimi.instance.canliDusmanlar.Count);

        skor.text = "Skor: " + Hedef.instance.anlikCan;
        bolumIndikatoru.text = "Level " + aktifSahne;
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene(aktifSahne);
    }

    public void SonrakiSeviyeYukle()
    {
        if (aktifSahne <= 14)
        {
            SceneManager.LoadScene(aktifSahne + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void BolumSecimEkrani()
    {
        SceneManager.LoadScene(16);
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
}
