using Chilligames.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Raw_model_update_build : MonoBehaviour
{
    public TextMeshProUGUI Text_time;
    public TextMeshProUGUI Text_level_to;
    public Slider Slider_time;

    //setting
   public  Update_build setting;

    DateTime Future_time;

    public void Change_value_model_update(Update_build setting_update_build)
    {
        //frist change
        setting = setting_update_build;


        Text_level_to.text = setting.To_level - 1 + "►" + setting.To_level;


        //fill time
        Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates.Deserilse_time deserilse_Time = ChilligamesJson.DeserializeObject<Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates.Deserilse_time>(setting.time);
        Future_time = new DateTime(deserilse_Time.Y, deserilse_Time.MO, deserilse_Time.D, deserilse_Time.H, deserilse_Time.M, deserilse_Time.S);
   

        Slider_time.maxValue = Future_time.Second + (Future_time.Minute * 60) + ((Future_time.Hour * 60) * 60);
        Slider_time.minValue = DateTime.Now.Second + (DateTime.Now.Minute * 60) + ((DateTime.Now.Hour * 60) * 60);

        StartCoroutine(timer());

    }

    IEnumerator timer()
    {
        while (true)
        {
            Slider_time.value = DateTime.Now.Second + (DateTime.Now.Minute * 60) + ((DateTime.Now.Hour * 60) * 60);

            Text_time.text = $"{Future_time.Hour} :{ Future_time.Minute }:{Future_time.Second} ";
            yield return new WaitForSeconds(1);
        }
    }


    public struct Update_build
    {
        public int To_level;
        public string time;
        public string ID;
        public Build.Type_build type_Build;

    }


}
