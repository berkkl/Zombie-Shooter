using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuYöneticisi : MonoBehaviour
{
    public static AnaMenuYöneticisi instance;

    private void Awake()
    {
        instance = this;
    }

    public int yeniOyunSahnesi; //seviye yöneticisinden son oynanan index kayıtlı olacak.

    public GameObject bilgiEkrani, bolumSecmeEkrani;

    public void OyunaBasla()
    {
        SceneManager.LoadScene(yeniOyunSahnesi);
    }
    
    public void OyundanCik()
    {
        Application.Quit();
    }
    
    public void BolumSecimEkraniAc()
    {
        bolumSecmeEkrani.SetActive(true);
    }

    public void BolumSecimEkraniKapat()
    {
        bolumSecmeEkrani.SetActive(false);
    }

    public void bilgiEkraniAc()
    {
        bilgiEkrani.SetActive(true);
    }

    public void bilgiEkraniKapa()
    {
        bilgiEkrani.SetActive(false);
    }
}
