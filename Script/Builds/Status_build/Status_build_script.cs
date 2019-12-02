using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Status_build_script : MonoBehaviour
{
    public Button BTN_udpate;


    public TextMeshProUGUI Text_namebuild;
    public Slider Slider_health;

    public void Change_value(Status_build Setting_status)
    {
        //change frist
        Text_namebuild.text = Setting_status.Name_build + $"[{Setting_status.Level}]";


        Slider_health.value = Setting_status.Health;


        switch (Setting_status.Type)
        {
            case Build.Type_build.Build_wood:
                {
                    BTN_udpate.onClick.AddListener(() =>
                    {
                        Server_side.User_data.Update_build(new Server_side.Models.Req_update_build { ID_Build = Setting_status.ID_build, Password = "85245685", Type_build = Build.Type_build.Build_wood, Username = "Hossyn" });
                    });
                }
                break;
            case Build.Type_build.Build_food:
                {
                    BTN_udpate.onClick.AddListener(() =>
                    {
                        Server_side.User_data.Update_build(new Server_side.Models.Req_update_build { ID_Build = Setting_status.ID_build, Password = "85245685", Type_build = Build.Type_build.Build_food, Username = "Hossyn" });
                    });
                }
                break;
            case Build.Type_build.Build_stone:
                {
                    BTN_udpate.onClick.AddListener(() =>
                    {
                        Server_side.User_data.Update_build(new Server_side.Models.Req_update_build { ID_Build = Setting_status.ID_build, Password = "85245685", Type_build = Build.Type_build.Build_stone, Username = "Hossyn" });
                    });
                }
                break;
            case Build.Type_build.Build_storage:
                {
                    BTN_udpate.onClick.AddListener(() =>
                    {
                        Server_side.User_data.Update_build(new Server_side.Models.Req_update_build { ID_Build = Setting_status.ID_build, Password = "85245685", Type_build = Build.Type_build.Build_storage, Username = "Hossyn" });
                    });
                }
                break;
        }

        //change acation btn
        BTN_udpate.onClick.AddListener(() =>
        {
            print("hi");
            Server_side.User_data.Update_build(new Server_side.Models.Req_update_build
            {
                Username = "Hossyn",
                Password = "85245685",
                ID_Build = Setting_status.ID_build,
                Type_build = Setting_status.Type
            });
        });
        
    }

    
    void Update()
    {
        //fllow camera
        transform.rotation = Camera.main.transform.rotation;

        //scale gameobject in zoom
        gameObject.transform.localScale = new Vector3(Camera.main.fieldOfView / 100, Camera.main.fieldOfView / 100, 1);
    }



    public struct Status_build
    {
        public string Name_build;
        public string ID_build;
        public int Level;
        public int Health;
        public Build.Type_build Type;
    }

}
