using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_build_area : MonoBehaviour
{

    [Header("Build_element")]
    public Button BTN_wood_build;
    public Button BTN_Stone_build;
    public Button BTN_meat_build;
    public Button BTN_storage_build;



    [Header("Raw_objects")]
    public GameObject Raw_wood_build;
    public GameObject Raw_stone_build;
    public GameObject Raw_meat_build;
    public GameObject Raw_storage;

    void Start()
    {
        //work_BTNs
        BTN_wood_build.onClick.AddListener(() =>
        {
            Instantiate(Raw_wood_build).GetComponent<Wooder>().Change_value(Build.Status_build.Frist_creat, new Build.Setting_Build_ressures { });
        });

        BTN_Stone_build.onClick.AddListener(() =>
        {
            Instantiate(Raw_stone_build).GetComponent<Stone>().Change_value(Build.Status_build.Frist_creat, new Build.Setting_Build_ressures { });

        });

        BTN_meat_build.onClick.AddListener(() =>
        {
            Instantiate(Raw_meat_build).GetComponent<Food_build>().Change_value(Build.Status_build.Frist_creat, new Build.Setting_Build_ressures { });
        });

        BTN_storage_build.onClick.AddListener(() =>
        {
            Instantiate(Raw_storage).GetComponent<raw_storage>().Change_value(Build.Status_build.Frist_creat, new Build.Setting_Build_ressures { });

        });



    }

    
}
