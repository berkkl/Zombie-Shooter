using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolumSecme : MonoBehaviour
{
    public string oynanacakBolum;

    public void BolumuAc()
    {
        SceneManager.LoadScene(oynanacakBolum);
    }
}
