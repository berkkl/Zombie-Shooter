using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesYonetimi : MonoBehaviour
{
    public static SesYonetimi instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public AudioSource menuMusic, levelSelectMusic;
    //public AudioSource[] bgm;
    
    //private int anlikBGM;
    //private bool aktifMiBGM;
    
    public AudioSource[] sfx;




    public void OynatSFX(int oynatilacakSFX)
    {
        sfx[oynatilacakSFX].Play();
        if (oynatilacakSFX == 1)
        {
            sfx[oynatilacakSFX].volume = 0.05f;
        }
        else
        {
            sfx[oynatilacakSFX].volume = 1f;
        }
    }
}
