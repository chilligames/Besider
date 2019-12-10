using Chilligames.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update_area : MonoBehaviour
{

    public static GameObject GmUpdateArea;

    [Header("Raw_model")]
    public GameObject Raw_model_update_detail;
  

    [Header("Setting")]
    public TextMeshProUGUI text_worker_count;
    public Transform place_update;
    public RawImage Image_icon_update;

    int Count_worker;
    int Count_work;

    public GameObject[] Worker;

    void Start()
    {
        //fill update for accese other script;
        GmUpdateArea = gameObject;

        //start recive
        Recive_Frist_detail_workers();
    }

    void Recive_Frist_detail_workers()
    {
        Server_side.User_data.Recive_worker_detail(new Server_side.Models.Req_recive_worker_detail { Password = "85245685", Username = "Hossyn" }, result =>
        {
            //fill worker text count
            Count_worker = result.Count_worker;
            Count_work = result.Count_work;
            text_worker_count.text = Count_worker + " / " + Count_work;


            //instant new work
            if (Worker == null || Worker.Length <= 0)
            {
                Worker = new GameObject[result.Updates.Length];

                for (int i = 0; i < result.Updates.Length; i++)
                {
                    Worker[i] = Instantiate(Raw_model_update_detail, place_update);
                    Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates deserilse_Updates = ChilligamesJson.DeserializeObject<Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates>(result.Updates[i].ToString());
                    Worker[i].GetComponent<Raw_model_update_build>().Change_value_model_update(new Raw_model_update_build.Update_build
                    {
                        To_level = deserilse_Updates.To_level,
                        type_Build = (Build.Type_build)deserilse_Updates.Type_build,
                        time = deserilse_Updates.Deserilze_time.ToString(),
                        ID = deserilse_Updates.ID_Build
                    });
                }
            }
        });
    }


    public void UpdateNewBuild(Raw_model_update_build.Update_build Detail_update)
    {
        //fill old worker
        var old_workers = new GameObject[Worker.Length + 1];

        for (int o = 0; o < Worker.Length; o++)
        {
            old_workers[o] = Worker[o];
        }

        //new worker add
        for (int n = 0; n < old_workers.Length; n++)
        {
            if (old_workers[n] == null)
            {
                old_workers[n] = Instantiate(Raw_model_update_detail, place_update);
                old_workers[n].GetComponent<Raw_model_update_build>().Change_value_model_update(Detail_update);
            }
        }
        
        Count_work++;
        text_worker_count.text = Count_worker + "/" + Count_work;

        Worker = old_workers;
    }

}
