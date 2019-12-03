using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePlay : MonoBehaviour
{
    [Header("Internal Object")]
    public GameObject Panel_UI;
    public GameObject Panel_pause;

 
    private void Update()
    {
        //Control_pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel_UI.SetActive(false);
            Panel_pause.SetActive(true);
        }


    }

   
}