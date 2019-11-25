using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooder : Build
{

    public override void Change_value(Status_build status_Build, Setting_Build_ressures setting)
    {
        Setting_build.Status_build = status_Build;
        Setting_build = setting;
        GetComponentInChildren<Status_build_script>().Change_value(new Status_build_script.Status_build { Name_build = Setting_build.Name, Health = Setting_build.Health, Level = Setting_build.Level });
    }


    public override void Update()
    {

        switch (Setting_build.Status_build)
        {
            case Status_build.Frist_creat:
                {
                    RaycastHit raycastHit;

                    var ray_for_creat = Camera.main.ScreenPointToRay(Input.mousePosition);

                    Physics.Raycast(ray_for_creat, out raycastHit);
                    gameObject.transform.position = new Vector3(raycastHit.point.x, 0, raycastHit.point.z); ;
                    if (Input.GetMouseButton(0))
                    {
                        //change status
                        Setting_build.Status_build = Status_build.Befor_build;

                        //send req build
                        Server_side.User_data.Creat_wood_build(new Server_side.Models.req_Creat_wood_build { Username = "Hossyn", Password = "85245685", Postion_build = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z)) });
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

