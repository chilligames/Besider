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


    [Header("resource_element")]
    public TextMeshProUGUI Text_food_number_value;
    public TextMeshProUGUI Text_wood_number_value;
    public TextMeshProUGUI Text_stone_number_value;



    [Header("Raw_objects")]
    public GameObject Raw_wood_build;
    public GameObject Raw_stone_build;
    public GameObject Raw_meat_build;

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

            Server_side.User_data.Recive_resource_value(new Server_side.Models.Req_Recive_resource_value { Password = "85245685", Username = "Hossyn" }, result =>
                  {
                      Text_wood_number_value.text = result.Wood.ToString();
                      Text_food_number_value.text = result.Food.ToString();
                      Text_stone_number_value.text = result.Stone.ToString();
                  });
        }

    }

}
