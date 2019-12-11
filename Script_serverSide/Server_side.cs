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
            public Build.Type_build Type;
        }
        public class req_Creat_food_build
        {
            public string Username;
            public string Password;
            public Vector3 Postion_build;
            public Build.Type_build Type;
        }
        public class req_Creat_stone_build
        {
            public string Username;
            public string Password;
            public Vector3 Postion_build;
            public Build.Type_build Type;
        }
        public class Req_creat_storage
        {
            public string Username;
            public string Passwod;
            public Vector3 Postion;
            public Build.Type_build Type;
        }
        public class Req_recive_info_pos
        {
            public Vector3 postions_camera;
        }
        public class Req_recive_per_value
        {
            public string Username;
            public string Password;
        }
        public class Req_update_build
        {
            public string Username;
            public string Password;
            public string ID_Build;
            public Build.Type_build Type_build;
        }
        public class Req_recive_worker_detail
        {
            public string Username;
            public string Password;
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

        public static async void Recive_value_per_Values(Req_recive_per_value req_Recive_Per_Value, Action<Result_recive_resource_value.Deserilse_Per_values> Result_per_value, Action<Result_recive_resource_value.Deserilise_values> Result_values, Action<int> Storage)
        {
            var www = UnityWebRequest.Get(map_url.Url_recive_resource_value_per_value);
            www.SetRequestHeader("username", req_Recive_Per_Value.Username);
            www.SetRequestHeader("password", req_Recive_Per_Value.Password);
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {

                    if (www.downloadHandler.text.Length >= 1)
                    {
                        var Deserilise_values = ChilligamesJson.DeserializeObject<Result_recive_resource_value>(www.downloadHandler.text);
                        Result_per_value(ChilligamesJson.DeserializeObject<Result_recive_resource_value.Deserilse_Per_values>(Deserilise_values.Per_Values.ToString()));
                        Result_values(ChilligamesJson.DeserializeObject<Result_recive_resource_value.Deserilise_values>(Deserilise_values.Values.ToString()));
                        Storage(Deserilise_values.Storage);
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
            www.SetRequestHeader("type_build", ((int)req_Creat_Wood_Build.Type).ToString());
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

        public static async void Creat_food_build(req_Creat_food_build req_Creat_food_Build)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_food_build);
            www.SetRequestHeader("username", req_Creat_food_Build.Username);
            www.SetRequestHeader("password", req_Creat_food_Build.Password);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Creat_food_Build.Postion_build));
            www.SetRequestHeader("type_build", ((int)req_Creat_food_Build.Type).ToString());
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

        public static async void Creat_stone_build(req_Creat_stone_build req_Stone_Build)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_stone_build);
            www.SetRequestHeader("username", req_Stone_Build.Username);
            www.SetRequestHeader("password", req_Stone_Build.Password);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Stone_Build.Postion_build));
            www.SetRequestHeader("type_build", ((int)req_Stone_Build.Type).ToString());
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

        public static async void Creat_storage(Req_creat_storage req_Creat_Storage)
        {
            var www = UnityWebRequest.Get(map_url.Url_creat_storage);
            www.SetRequestHeader("username", req_Creat_Storage.Username);
            www.SetRequestHeader("password", req_Creat_Storage.Passwod);
            www.SetRequestHeader("postion", JsonUtility.ToJson(req_Creat_Storage.Postion));
            www.SetRequestHeader("type_build", ((int)req_Creat_Storage.Type).ToString());
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


        public static async void Update_build(Req_update_build req_Update_Build, Action<Result_Update> Result_update)
        {
            var www = UnityWebRequest.Get(map_url.Url_update_build);
            www.SetRequestHeader("username", req_Update_Build.Username);
            www.SetRequestHeader("password", req_Update_Build.Password);
            www.SetRequestHeader("type_build", ((int)req_Update_Build.Type_build).ToString());
            www.SetRequestHeader("id_build", req_Update_Build.ID_Build);
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Length > 2)
                    {
                        print(www.downloadHandler.text);
                        Result_update(ChilligamesJson.DeserializeObject<Result_Update>(www.downloadHandler.text));
                    }
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


        public static async void Recive_worker_detail(Req_recive_worker_detail req_Recive_Worker_Detail, Action<Result_recive_worker_detail> result)
        {
            var www = UnityWebRequest.Get(map_url.Url_recive_worker_detail);
            www.SetRequestHeader("username", req_Recive_Worker_Detail.Username);
            www.SetRequestHeader("password", req_Recive_Worker_Detail.Password);
            www.SendWebRequest();
            while (true)
            {
                if (www.isDone)
                {
                    www.Abort();
                    result(ChilligamesJson.DeserializeObject<Result_recive_worker_detail>(www.downloadHandler.text));
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
                public object Values;
                public object Per_Values;
                public int Storage;

                public class Deserilise_values
                {
                    public int Wood;
                    public int Food;
                    public int Stone;

                }
                public class Deserilse_Per_values
                {
                    public int Per_Value_Wood;
                    public int Per_Value_Food;
                    public int Per_Value_Stone;

                }
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
                    public int Type_build;
                }
            }

            public class Result_Update
            {
                public string ID_Build;
                public int To_level;
                public int Type_build;
                public int Time;
                public object Deserilze_time;
                public class Deserilse_time
                {
                    public int Y;
                    public int MO;
                    public int D;

                    public int H;
                    public int M;
                    public int S;
                }

            }

            public class Result_recive_worker_detail
            {
                public int Count_worker;
                public int Count_work;
                public object[] Updates;

                public class Deserilse_updates
                {
                    public string ID_Build;
                    public int To_level;
                    public int Type_build;
                    public int Time;
                    public object Deserilze_time;
                    public class Deserilse_time
                    {
                        public int Y;
                        public int MO;
                        public int D;

                        public int H;
                        public int M;
                        public int S;
                    }
                }
            }
        }

    }

    public struct Map_Url
    {
        public string Url_login => "http://127.0.0.1:3333/Register";

        public string Url_recive_resource_value_per_value => "http://127.0.0.1:3333/resource_value";
        public string Url_creat_wood_build => "http://127.0.0.1:3333/creat_wood_build";
        public string Url_creat_food_build => "http://127.0.0.1:3333/creat_food_build";
        public string Url_creat_stone_build => "http://127.0.0.1:3333/creat_stone_build";
        public string Url_recive_info_pos => "http://127.0.0.1:3333/recive_data_pos";
        public string Url_creat_storage => "http://127.0.0.1:3333/creat_storage";
        public string Url_update_build => "http://127.0.0.1:3333/update_build";
        public string Url_recive_worker_detail => "http://127.0.0.1:3333/recive_worker_detail";
    }

}
