using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Build
{
    public override void Change_value(Status_build status_Build, Setting_Build_ressures setting)
    {
        //frist value fill
        Setting_build.Status_build = status_Build;
        Setting_build = setting;

        //change status 
        GetComponentInChildren<Status_build_script>().Change_value(new Status_build_script.Status_build_setting { Level = 1, Health = 100, Name_build = "build", Type = Type_build.Build_stone, ID_build = Setting_build.ID });

    }

    public override void Update()
    {
        switch (Setting_build.Status_build)
        {
            case Status_build.Frist_creat:
                {
                    RaycastHit info_ray;

                    Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out info_ray);

                    transform.position = new Vector3(info_ray.point.x, 0, info_ray.point.z);

                    if (Input.GetMouseButton(0))
                    {
                        //change status
                        Setting_build.Status_build = Status_build.Befor_build;

                        //send req build in server
                        Server_side.User_data.Creat_stone_build(new Server_side.Models.req_Creat_stone_build { Password = "85245685", Username = "Hossyn", Postion_build = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)),Type=Type_build.Build_stone });
                        Destroy(gameObject);
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        Destroy(gameObject);
                    }

                }
                break;
            case Status_build.Befor_build:
                {
                    print("code bvefore here");
                }
                break;
        }
    }

    public override IEnumerator Update_each_build()
    {
        throw new System.NotImplementedException();
    }
}
