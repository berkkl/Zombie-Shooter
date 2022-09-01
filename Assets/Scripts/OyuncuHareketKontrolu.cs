using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareketKontrolu : MonoBehaviour
{
    private CharacterController karakterKontrol;
    public float karakterHizi = 3f;

    private bool hareketHalinde;

    public Animator animasyon;

    private void Start()
    {
        karakterKontrol = GetComponent<CharacterController>();

    }

    private void Update()
    {
        if(SeviyeYonetimi.instance.seviyeAktif)
        {
            karakterHareketi();
            animasyon.SetBool("HareketHalinde", hareketHalinde);
        }
    }

    void karakterHareketi()
    {
        if(!SesYonetimi.instance.sfx[1].isPlaying && hareketHalinde)
        {
            SesYonetimi.instance.OynatSFX(1);
        }
        float xDegeri = Input.GetAxis("Horizontal") * Time.deltaTime * karakterHizi;
        float zDegeri = Input.GetAxis("Vertical") * Time.deltaTime * karakterHizi;
        if (xDegeri != 0 || zDegeri != 0)
        {
            hareketHalinde = true;
        }
        else
        {
            hareketHalinde = false;
        }
        transform.Translate(xDegeri, 0 , zDegeri);
    }
}
