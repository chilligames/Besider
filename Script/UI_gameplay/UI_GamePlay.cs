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

    [Header("Build_element")]
    public Button BTN_wood_build;
    public Button BTN_Stone_build;
    public Button BTN_meat_build;
    public Button BTN_storage_build;

    [Header("resource_element")]
    public TextMeshProUGUI Text_food_number_value;
    public TextMeshProUGUI Text_wood_number_value;
    public TextMeshProUGUI Text_stone_number_value;

    public TextMeshProUGUI Text_wood_per_value;
    public TextMeshProUGUI Text_food_per_value;
    public TextMeshProUGUI Text_stone_per_value;

    public TextMeshProUGUI Text_storage_wood;
    public TextMeshProUGUI Text_storage_food;
    public TextMeshProUGUI Text_storage_stone;


    [Header("Raw_objects")]
    public GameObject Raw_wood_build;
    public GameObject Raw_stone_build;
    public GameObject Raw_meat_build;
    public GameObject Raw_storage;

    private void Start()
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

        //recive data from server
        StartCoroutine(Recive_resource());
    }

    private void Update()
    {
        //Control_pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel_UI.SetActive(false);
            Panel_pause.SetActive(true);
        }


    }


    IEnumerator Recive_resource()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            Server_side.User_data.Recive_value_per_Values(new Server_side.Models.Req_recive_per_value { Password = "85245685", Username = "Hossyn" },
                result_per_value =>
            {
                //change value per value
                Text_wood_per_value.text = result_per_value.Per_Value_Wood.ToString();
                Text_food_per_value.text = result_per_value.Per_Value_Food.ToString();
                Text_stone_per_value.text = result_per_value.Per_Value_Stone.ToString();


            }, result_value =>
            {
                Text_wood_number_value.text = result_value.Wood.ToString();
                Text_food_number_value.text = result_value.Food.ToString();
                Text_stone_number_value.text = result_value.Stone.ToString();


            }, Storage =>
            {
                Text_storage_wood.text = Storage.ToString();
                Text_storage_food.text = Storage.ToString();
                Text_storage_stone.text = Storage.ToString();

            });

        }
    }

}