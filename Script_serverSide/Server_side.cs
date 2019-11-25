using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using static Server_side.Models;
using static Server_side.User_data.Result_data;
using Chilligames.Json;
public class Server_side
{
    public class Models
    {
        public class Req_Login_palyer
        {
            public string Username;
            public string Password;
        }
        public class Req_Recive_resource_value
        {
            public string Username;
            public string Password;

        }
        public class req_Creat_wood_build
        {
            public string Username;
            public string Password;
            public Vector3 Postion_build;
        }
        public class req_Creat_food_build
        {
            public string Username;
            public string Password;
            public Vector3 Postion_build;
        }
        public class req_stone_build
        {
            public string Username;
            public string Password;
            public Vector3 Postion_build;
        }

        public class Req_recive_info_pos
        {
            public Vector3 postions_camera;
        }

    }

    public class User_data : MonoBehaviour
    {
        public static Map_Url map_url;

        public static async void Login_Player(Req_Login_palyer Recive_all_data, Action result)
        {
            var www = UnityWebRequest.Get(map_url.Url_login);
            www.SetRequestHeader("username", Recive_all_data.Username);
            www.SetRequestHeader("password", Recive_all_data.Password);
            www.SendWebRequest();

            while (true)
            {
                if (www.isDone)
                {

                    break;

                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }
            }
        }

        public static async void Recive_resource_value(Req_Recive_resource_value recive_Resource_Value, Action<Result_recive_resource_value> Result)
        {
            var www = UnityWebRequest.Get(map_url.Url_recive_resource_value);
            www.SetRequestHeader("username", recive_Resource_Value.Username);
            www.SetRequestHeader("password", recive_Resource_Value.Password);
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Length > 2)
                    {
                        Result(JsonUtility.FromJson<Result_recive_resource_value>(www.downloadHandler.text));
                    }
                    else
                    {
                        print("recive faild");
                    }

                    break;
                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }

            }


        }


        public static async void Creat_wood_build(req_Creat_wood_build req_Creat_Wood_Build)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_wood_build);
            www.SetRequestHeader("username", req_Creat_Wood_Build.Username);
            www.SetRequestHeader("password", req_Creat_Wood_Build.Password);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Creat_Wood_Build.Postion_build));
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    www.Abort();
                    break;
                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }
            }
        }

        public static async void Creat_food_build(req_Creat_food_build req_Creat_Wood_Build)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_food_build);
            www.SetRequestHeader("username", req_Creat_Wood_Build.Username);
            www.SetRequestHeader("password", req_Creat_Wood_Build.Password);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Creat_Wood_Build.Postion_build));
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    www.Abort();
                    break;
                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }
            }
        }

        public static async void Creat_stone_build(req_stone_build req_Stone_Build)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_stone_build);
            www.SetRequestHeader("username", req_Stone_Build.Username);
            www.SetRequestHeader("password", req_Stone_Build.Password);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Stone_Build.Postion_build));
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    www.Abort();
                    break;
                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }
            }
        }

        public static async void Recive_info_pos(Req_recive_info_pos req_Recive_Info_Pos, Action<Result_recive_postion_info> Builds)
        {
            var www = UnityWebRequest.Get(map_url.Url_recive_info_pos);
            www.SetRequestHeader("postions", JsonUtility.ToJson(req_Recive_Info_Pos.postions_camera));

            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Length >= 1)
                    {
                        Builds(ChilligamesJson.DeserializeObject<Result_recive_postion_info>(www.downloadHandler.text));
                    }
                    break;
                }
                else
                {
                    if (www.isHttpError || www.isNetworkError || www.timeout == 1)
                    {
                        www.Abort();
                        break;
                    }
                    await Task.Delay(1);
                }

            }
        }


        public class Result_data
        {
            public class Result_recive_resource_value
            {
                public int Wood;
                public int Food;
                public int Stone;
            }

            public class Result_recive_postion_info
            {
                public object[] Builds;

                public class Desrilse_build
                {
                    public string ID;
                    public string Name;
                    public int Level;
                    public int Health;
                    public int Storage;
                    public object Postion;

                }
            }

        }

    }

    public struct Map_Url
    {
        public string Url_login => "http://127.0.0.1:3333/Register";

        public string Url_recive_resource_value => "http://127.0.0.1:3333/resource_value";
        public string Url_creat_wood_build => "http://127.0.0.1:3333/creat_wood_build";
        public string Url_creat_food_build => "http://127.0.0.1:3333/creat_food_build";
        public string Url_creat_stone_build => "http://127.0.0.1:3333/creat_stone_build";
        public string Url_recive_info_pos => "http://127.0.0.1:3333/recive_data_pos";
    }

}
