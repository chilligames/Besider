using Chilligames.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Raw_model_update_build : MonoBehaviour
{
    public TextMeshProUGUI Text_time;
    public TextMeshProUGUI Text_level_to;
    Update_build setting;


    public void Change_value_model_update(Update_build setting_update_build)
    {
        //frist change
        setting = setting_update_build;


        Text_level_to.text = setting.To_level - 1 + "►" + setting.To_level;

        Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates.Deserilse_time deserilse_Time = ChilligamesJson.DeserializeObject<Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates.Deserilse_time>(setting.time);


        var Time = DateTime.Parse($"{deserilse_Time.Y}/{deserilse_Time.MO}/{deserilse_Time.D} {deserilse_Time.H}:{deserilse_Time.M}:{deserilse_Time.S}");

        print(DateTime.Now);
        Text_time.text = Time.ToString();

    }


    public struct Update_build
    {
        public int To_level;
        public string time;
        public Build.Type_build type_Build;

    }


}
