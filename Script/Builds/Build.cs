using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Build : MonoBehaviour
{
    public Setting_Build_ressures Setting_build;


    /// <summary>
    /// change value builds
    /// </summary>
    /// <param name="status_Build"></param>
    public abstract void Change_value(Status_build status_Build, Setting_Build_ressures Setting);

    public abstract void Update();

    public abstract IEnumerator Update_each_build();

    public struct Setting_Build_ressures
    {
        public string ID;
        public string Name;
        public int Level;
        public int Storage;
        public int Health;
        public Vector3 postion_build;
        public Status_build Status_build;
    }

    public enum Status_build
    {
        Frist_creat, Befor_build
    }


    public enum Type_build
    {
        Build_wood,Build_food,Build_stone
    }

}
