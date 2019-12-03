using Chilligames.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Update_area : MonoBehaviour
{

    [Header("Raw_model")]
    public GameObject Raw_model_update_detail;

    [Header("Setting")]
    public TextMeshProUGUI text_worker_count;
    public Transform place_update;

    GameObject[] Workers;

    void Start()
    {
        StartCoroutine(Recive_detail_workers());
    }

    IEnumerator Recive_detail_workers()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Server_side.User_data.Recive_worker_detail(new Server_side.Models.Req_recive_worker_detail { Password = "85245685", Username = "Hossyn" }, result =>
            {
                //fill worker text count
                text_worker_count.text = result.Count_worker + " / " + result.Count_work;

                if (Workers == null)
                {
                    Workers = new GameObject[result.Updates.Length];

                    for (int i = 0; i < result.Updates.Length; i++)
                    {
                        Workers[i] = Instantiate(Raw_model_update_detail, place_update);
                        Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates deserilse_Updates = ChilligamesJson.DeserializeObject<Server_side.User_data.Result_data.Result_recive_worker_detail.Deserilse_updates>(result.Updates[i].ToString());
                        Workers[i].GetComponent<Raw_model_update_build>().Change_value_model_update(new Raw_model_update_build.Update_build { To_level = deserilse_Updates.To_level, type_Build = (Build.Type_build)deserilse_Updates.Type_build, time = deserilse_Updates.Deserilze_time.ToString()});
                    }
                }

            });

        }
    }
}
