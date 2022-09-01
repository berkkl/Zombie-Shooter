using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    public float RotasyonHizi;
    public Transform Hedef, Oyuncu;
    private float mouseX, mouseY;

    private void Update()
    {
        if(!SeviyeYonetimi.instance.seviyeAktif)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void LateUpdate()
    {
        if(SeviyeYonetimi.instance.seviyeAktif)
        {
            KameraKontrol();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void KameraKontrol()
    {
        mouseX += Input.GetAxis("Mouse X") * RotasyonHizi;

        transform.LookAt(Hedef);
        
        Hedef.rotation = Quaternion.Euler(20, mouseX, 0);
        Oyuncu.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
