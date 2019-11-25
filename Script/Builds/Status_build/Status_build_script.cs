using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Status_build_script : MonoBehaviour
{
    public Button BTN_show_total_info;
    public Button BTN_hide_total_info;


    public GameObject Quick_info;
    public GameObject Tottal_info;

    public TextMeshProUGUI Text_namebuild;
    public Slider Slider_health;
    public TextMeshProUGUI Text_level;

    int anim_info;

    public void Change_value(Status_build Setting_status)
    {
        //change frist
        Text_namebuild.text = Setting_status.Name_build;
        Slider_health.maxValue = Setting_status.Health;
        Text_level.text = Setting_status.Level.ToString();

        //action btns
        BTN_show_total_info.onClick.AddListener(() =>
        {
            anim_info = 1;
        });

        BTN_hide_total_info.onClick.AddListener(() =>
        {
            anim_info = 2;
        });
    }

    void Update()
    {
        //fllow camera
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position);

        //scale gameobject in zoom
        gameObject.transform.localScale = new Vector3(Camera.main.fieldOfView / 100, Camera.main.fieldOfView / 100, 1);


        //anim show info
        if (anim_info == 1)
        {
            Tottal_info.transform.localScale = Vector3.MoveTowards(Tottal_info.transform.localScale, Vector3.one, 0.3f);
            Quick_info.transform.localPosition = Vector3.MoveTowards(Quick_info.transform.localPosition, new Vector3(Quick_info.transform.localPosition.x, 11, Quick_info.transform.localPosition.z), 0.3f);
        }
        else if (anim_info == 2)
        {
            Tottal_info.transform.localScale = Vector3.MoveTowards(Tottal_info.transform.localScale, Vector3.zero, 0.3f);
            Quick_info.transform.localPosition = Vector3.MoveTowards(Quick_info.transform.localPosition, Vector3.zero, 0.3f);
        }


    }



    public struct Status_build
    {
        public string Name_build;
        public int Level;
        public int Health;
    }

}
