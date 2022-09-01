using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public Rigidbody rb;
    public float mermiHizi;
    private float yokOlmaSayaci = 1.5f;
    public float mermiHasari = 5f;
    public GameObject vurusEfekti;
    
    private void Start()
    {
        rb.velocity = transform.forward * mermiHizi * Time.deltaTime;
    }

    private void Update()
    {
        yokOlmaSayaci -= Time.deltaTime;
        if (yokOlmaSayaci <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dusman")
        {
            Instantiate(vurusEfekti, other.transform.position, other.transform.rotation);
            SesYonetimi.instance.OynatSFX(0);
            other.GetComponent<DusmanKontrol>().HasarAl(mermiHasari);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
