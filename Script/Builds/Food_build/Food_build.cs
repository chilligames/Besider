using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_build : Build
{
    public override void Change_value(Status_build status_Build, Setting_Build_ressures setting)
    {
        Setting_build.Status_build = status_Build;
        Setting_build = setting;
        GetComponentInChildren<Status_build_script>().Change_value(new Status_build_script.Status_build { Health = 100, Level = 1, Name_build = "build" });

    }

    public override void Update()
    {
        switch (Setting_build.Status_build)
        {
            case Status_build.Frist_creat:
                {
                    RaycastHit ray_info;
                    Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out ray_info);
                    gameObject.transform.position = new Vector3(ray_info.point.x, 0, ray_info.point.z);

                    if (Input.GetMouseButton(0))
                    {
                        //change status build
                        Setting_build.Status_build = Status_build.Befor_build;
                        
                        //send req to server
                        Server_side.User_data.Creat_food_build(new Server_side.Models.req_Creat_food_build { Password = "85245685", Username = "Hossyn", Postion_build = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)) }); ;
                        Destroy(gameObject);
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        Destroy(gameObject);
                    }
                }
                break;

        }
    }

    public override IEnumerator Update_each_build()
    {
        throw new System.NotImplementedException();
    }
}
