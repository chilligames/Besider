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

    public GameObject[] Worker;

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

                if (Worker == null || Worker.Length <= 0)
                {
                    print("F");
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
                else
                {
                    print(result.Updates.Length);
                    var new_work = new GameObject[result.Updates.Length];

                    foreach (var item in Worker)
                    {
                        for (int a = 0; a < new_work.Length; a++)
                        {
                            if (new_work[a] == null)
                            {
                                new_work[a] = item;
                                break;
                            }
                        }

                    }

                    for (int i = 0; i < new_work.Length; i++)
                    {
                        if (new_work[i]==null)
                        {
                            print("hi");
                        }

                    }

                    //Worker = new_work;
                }

            });

        }
    }
}
