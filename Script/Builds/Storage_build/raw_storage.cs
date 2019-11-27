using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raw_storage : Build
{
    public override void Change_value(Status_build status_Build, Setting_Build_ressures Setting)
    {
        Setting_build.Status_build = status_Build;

        Setting_build = Setting;
        GetComponentInChildren<Status_build_script>().Change_value(new Status_build_script.Status_build { Health = Setting_build.Health, Level = Setting_build.Level, Name_build = Setting_build.Name });
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
                        Server_side.User_data.Creat_storage(new Server_side.Models.Req_creat_storage{ Passwod="85245685",Username="Hossyn",Postion=new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)) });
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

                }
                break;
        }

    }

    public override IEnumerator Update_each_build()
    {
        throw new System.NotImplementedException();
    }
}
