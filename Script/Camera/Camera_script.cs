using Chilligames.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Server_side.User_data.Result_data.Result_recive_postion_info;

public class Camera_script : MonoBehaviour
{


    [Header("Setting")]
    public float Speed_camera;
    public int X, Y;
    public int pos_x, pos_z;

    void Update()
    {
        //control camera with key
        if (Input.GetKey(KeyCode.W))
        {
            Transform T = transform;
            T.Translate(Vector3.forward * Time.deltaTime * 10);
            transform.position = new Vector3(T.position.x, 14, T.position.z);

        }
        if (Input.GetKey(KeyCode.S))
        {
            Transform T = transform;
            T.Translate(Vector3.back * Time.deltaTime * 10);
            transform.position = new Vector3(T.position.x, 14, T.position.z);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10);
        }


        //control mouse move
        if (Input.mousePosition.x >= Screen.width)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10);
        }
        else if (Input.mousePosition.x <= 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10);
        }

        if (Input.mousePosition.y >= Screen.height)
        {
            Transform T = transform;
            T.Translate(Vector3.forward * Time.deltaTime * 10);
            transform.position = new Vector3(T.position.x, 14, T.position.z);

        }
        else if (Input.mousePosition.y <= 0)
        {
            Transform T = transform;
            T.Translate(Vector3.back * Time.deltaTime * 10);
            transform.position = new Vector3(T.position.x, 14, T.position.z);
        }

        //control zoom
        if (Input.mouseScrollDelta == Vector2.down && Camera.main.fieldOfView <= 60)
        {
            Camera.main.fieldOfView += 5;
        }
        else if (Input.mouseScrollDelta == Vector2.up && Camera.main.fieldOfView >= 20)
        {
            Camera.main.fieldOfView -= 5;
        }

        //control rotate
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y + 5, Camera.main.transform.eulerAngles.z);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y - 5, Camera.main.transform.eulerAngles.z);
            }
        }


    }

}
