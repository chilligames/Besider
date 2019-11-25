﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Server_side.User_data.Result_data.Result_recive_postion_info;
using Chilligames.Json;

public class Build_reciver : MonoBehaviour
{

    [Header("Raw_models")]
    public GameObject Raw_wood_build;
    public GameObject Raw_food_build;
    public GameObject Raw_stone_build;



    [Header("reciver info")]
    public GameObject[] All_build_recive;


    private void Start()
    {
        StartCoroutine(Recive_data_map());
    }


    IEnumerator Recive_data_map()
    {

        yield return new WaitForSeconds(0.1f);

        Server_side.User_data.Recive_info_pos(new Server_side.Models.Req_recive_info_pos { postions_camera = new Vector3(Mathf.RoundToInt(Camera.main.transform.position.x), 0, Mathf.RoundToInt(Camera.main.transform.position.z)) }, result =>
        {

            if (All_build_recive.Length >= 1)
            {
                foreach (var item in result.Builds)
                {


                    Desrilse_build Info_build = new Desrilse_build
                    {
                        ID = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).ID,
                        Name = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Name,
                        Level = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Level,
                        Storage = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Storage,
                        Postion = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Postion,
                        Health = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Health,
                        Type_build = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Type_build

                    };

                    switch ((Build.Type_build)Info_build.Type_build)
                    {
                        case Build.Type_build.Build_wood:
                            {
                                bool Can_build = true;
                                foreach (var Woods_build in GetComponentsInChildren<Wooder>())
                                {
                                    if (Woods_build.GetComponent<Wooder>().Setting_build.ID == Info_build.ID)
                                    {
                                        Can_build = false;
                                    }
                                }

                                if (Can_build)
                                {
                                    print(Info_build.Name);
                                }

                            }
                            break;
                        case Build.Type_build.Build_food:
                            {

                            }
                            break;
                        case Build.Type_build.Build_stone:
                            {

                            }
                            break;
                    }

                }

            }
            else
            {
                All_build_recive = new GameObject[result.Builds.Length];

                    //desrilise from server
                    foreach (var item in result.Builds)
                {
                    Desrilse_build Info_build = new Desrilse_build
                    {
                        ID = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).ID,
                        Name = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Name,
                        Level = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Level,
                        Storage = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Storage,
                        Postion = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Postion,
                        Health = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Health,
                        Type_build = ChilligamesJson.DeserializeObject<Desrilse_build>(item.ToString()).Type_build

                    };

                    print(Info_build.Name);


                        //build 
                        switch ((Build.Type_build)Info_build.Type_build)
                    {
                        case Build.Type_build.Build_wood:
                            {
                                Vector3 postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());

                                for (int i = 0; i < All_build_recive.Length; i++)
                                {
                                    if (All_build_recive[i] == null)
                                    {
                                        All_build_recive[i] = Instantiate(Raw_wood_build, postion, transform.rotation, transform);
                                        All_build_recive[i].GetComponent<Wooder>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                        {
                                            Status_build = Build.Status_build.Befor_build,
                                            Health = Info_build.Health,
                                            ID = Info_build.ID,
                                            Level = Info_build.Level,
                                            Name = Info_build.Name,
                                            postion_build = postion,
                                            Storage = Info_build.Storage

                                        });

                                        break;

                                    }

                                }
                            }
                            break;
                        case Build.Type_build.Build_food:
                            {
                                Vector3 postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());

                                for (int i = 0; i < All_build_recive.Length; i++)
                                {
                                    if (All_build_recive[i] == null)
                                    {
                                        All_build_recive[i] = Instantiate(Raw_food_build, postion, transform.rotation, transform);
                                        All_build_recive[i].GetComponent<Food_build>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                        {
                                            Status_build = Build.Status_build.Befor_build,
                                            Health = Info_build.Health,
                                            ID = Info_build.ID,
                                            Level = Info_build.Level,
                                            Name = Info_build.Name,
                                            postion_build = postion,
                                            Storage = Info_build.Storage
                                        });
                                        break;
                                    }
                                }
                            }
                            break;
                        case Build.Type_build.Build_stone:
                            {
                                Vector3 postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());

                                for (int i = 0; i < All_build_recive.Length; i++)
                                {
                                    if (All_build_recive[i] == null)
                                    {
                                        All_build_recive[i] = Instantiate(Raw_stone_build, postion, transform.rotation, transform);
                                        All_build_recive[i].GetComponent<Stone>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                        {

                                            Health = Info_build.Health,
                                            ID = Info_build.ID,
                                            Status_build = Build.Status_build.Befor_build,
                                            Level = Info_build.Level,
                                            Name = Info_build.Name,
                                            postion_build = postion,
                                            Storage = Info_build.Storage

                                        });
                                        break;
                                    }

                                }

                            }
                            break;

                    }


                }

            }

        });

    }
}
