using System.Collections;
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
    public GameObject Raw_storage_build;


    [Header("reciver info")]
    public GameObject[] All_build_recive;

    Vector3 Camera_pos;
    bool Lock_recive = true;
    private void Start()
    {
        Camera_pos = Camera.main.transform.position;
        StartCoroutine(recive_data_postion());
    }

    IEnumerator recive_data_postion()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);

            Server_side.User_data.Recive_info_pos(new Server_side.Models.Req_recive_info_pos { postions_camera = new Vector3(Mathf.RoundToInt(Camera.main.transform.position.x), 0, Mathf.RoundToInt(Camera.main.transform.position.z)) }, result =>
            {
                if (All_build_recive.Length >= 1 /*&& Camera.main.transform.position != Camera_pos*/)
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
                                    var postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());

                                    //cheak for new build
                                    bool can_build = true;
                                    foreach (var WoodBuilds in GetComponentsInChildren<Wooder>())
                                    {
                                        if (WoodBuilds.GetComponent<Wooder>().Setting_build.ID == Info_build.ID)
                                        {
                                            can_build = false;
                                            break;
                                        }


                                    }

                                    //build new build

                                    if (can_build && Lock_recive)
                                    {
                                        //lock recive
                                        Lock_recive = false;

                                        //recive work
                                        var old_build = All_build_recive;

                                        All_build_recive = new GameObject[result.Builds.Length + All_build_recive.Length];//cheack

                                        for (int A = 0; A < old_build.Length; A++)
                                        {
                                            All_build_recive[A] = old_build[A];
                                        }

                                        for (int i = 0; i < All_build_recive.Length; i++)
                                        {
                                            if (All_build_recive[i] == null)
                                            {
                                              
                                                All_build_recive[i] = Instantiate(Raw_wood_build, postion, transform.rotation, transform);
                                                All_build_recive[i].GetComponent<Wooder>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                                {
                                                    Health = Info_build.Health,
                                                    Status_build = Build.Status_build.Befor_build,
                                                    ID = Info_build.ID,
                                                    Level = Info_build.Level,
                                                    Name = Info_build.Name,
                                                    postion_build = postion,
                                                    Storage = Info_build.Storage,
                                                    Type_build = Build.Type_build.Build_wood

                                                });
                                                break;
                                            }

                                        }

                                    }

                                    //recive unlock
                                    Lock_recive = true;
                                }
                                break;
                            case Build.Type_build.Build_food:
                                {

                                    //cheak for new build
                                    var postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());
                                    bool can_build = true;

                                    foreach (var food_build in GetComponentsInChildren<Food_build>())
                                    {
                                        if (food_build.GetComponent<Food_build>().Setting_build.ID == Info_build.ID)
                                        {
                                            can_build = false;
                                            break;
                                        }

                                    }

                                    //build new build

                                    if (can_build && Lock_recive)
                                    {
                                        //lock recive
                                        Lock_recive = false;

                                        var old_build = All_build_recive;

                                        All_build_recive = new GameObject[result.Builds.Length + old_build.Length];

                                        for (int A = 0; A < old_build.Length; A++)
                                        {
                                            All_build_recive[A] = old_build[A];
                                        }
                                        for (int i = 0; i < All_build_recive.Length; i++)
                                        {
                                            if (All_build_recive[i] == null)
                                            {
                                                All_build_recive[i] = Instantiate(Raw_food_build, postion, transform.rotation, transform);
                                                All_build_recive[i].GetComponent<Food_build>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                                {
                                                    Health = Info_build.Health,
                                                    Status_build = Build.Status_build.Befor_build,
                                                    ID = Info_build.ID,
                                                    Level = Info_build.Level,
                                                    Name = Info_build.Name,
                                                    postion_build = postion,
                                                    Storage = Info_build.Storage,
                                                    Type_build = Build.Type_build.Build_food

                                                });
                                                break;
                                            }

                                        }
                                    }

                                    //unlock recive
                                    Lock_recive = true;
                                }
                                break;
                            case Build.Type_build.Build_stone:
                                {

                                    var postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());
                                    //cheak for new build
                                    bool can_build = true;

                                    foreach (var Stone_build in GetComponentsInChildren<Stone>())
                                    {
                                        if (Stone_build.GetComponent<Stone>().Setting_build.ID == Info_build.ID)
                                        {
                                            can_build = false;
                                            break;
                                        }

                                    }

                                    //build new build

                                    if (can_build && Lock_recive)
                                    {
                                        //lock recive 
                                        Lock_recive = false;

                                        var old_build = All_build_recive;
                                        All_build_recive = new GameObject[result.Builds.Length + old_build.Length];

                                        for (int A = 0; A < old_build.Length; A++)
                                        {
                                            All_build_recive[A] = old_build[A];
                                        }
                                        for (int i = 0; i < All_build_recive.Length; i++)
                                        {
                                            if (All_build_recive[i] == null)
                                            {
                                                All_build_recive[i] = Instantiate(Raw_stone_build, postion, transform.rotation, transform);
                                                All_build_recive[i].GetComponent<Stone>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                                {
                                                    Health = Info_build.Health,
                                                    Status_build = Build.Status_build.Befor_build,
                                                    ID = Info_build.ID,
                                                    Level = Info_build.Level,
                                                    Name = Info_build.Name,
                                                    postion_build = postion,
                                                    Storage = Info_build.Storage,
                                                    Type_build = Build.Type_build.Build_stone

                                                });
                                                break;
                                            }

                                        }


                                    }

                                    //unlock recive
                                    Lock_recive = true;
                                }
                                break;
                            case Build.Type_build.Build_storage:
                                {

                                    var postion = JsonUtility.FromJson<Vector3>(Info_build.Postion.ToString());
                                    //cheak for new build
                                    bool can_build = true;

                                    foreach (var Storage in GetComponentsInChildren<raw_storage>())
                                    {
                                        if (Storage.GetComponent<raw_storage>().Setting_build.ID == Info_build.ID)
                                        {
                                            can_build = false;
                                            break;
                                        }

                                    }

                                    //build new build

                                    if (can_build && Lock_recive)
                                    {
                                        //lock recive 
                                        Lock_recive = false;

                                        var old_build = All_build_recive;
                                        All_build_recive = new GameObject[result.Builds.Length + old_build.Length];

                                        for (int A = 0; A < old_build.Length; A++)
                                        {
                                            All_build_recive[A] = old_build[A];
                                        }
                                        for (int i = 0; i < All_build_recive.Length; i++)
                                        {
                                            if (All_build_recive[i] == null)
                                            {
                                                All_build_recive[i] = Instantiate(Raw_storage_build, postion, transform.rotation, transform);
                                                All_build_recive[i].GetComponent<raw_storage>().Change_value(Build.Status_build.Befor_build, new Build.Setting_Build_ressures
                                                {
                                                    Health = Info_build.Health,
                                                    Status_build = Build.Status_build.Befor_build,
                                                    ID = Info_build.ID,
                                                    Level = Info_build.Level,
                                                    Name = Info_build.Name,
                                                    postion_build = postion,
                                                    Storage = Info_build.Storage
                                                    ,
                                                    Type_build = Build.Type_build.Build_storage
                                                });
                                                break;
                                            }

                                        }


                                    }

                                    //unlock recive
                                    Lock_recive = true;

                                }
                                break;
                        }
                    }

                    Camera_pos = Camera.main.transform.position;
                }
                else if (All_build_recive.Length <= 0 && Lock_recive)
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
                                                Storage = Info_build.Storage,
                                                Type_build = Build.Type_build.Build_wood

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
                                                Storage = Info_build.Storage,
                                                Type_build = Build.Type_build.Build_food
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
                                                Storage = Info_build.Storage,
                                                Type_build = Build.Type_build.Build_stone

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
}
