using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Detail_resource : MonoBehaviour
{

    [Header("resource_element")]
    public TextMeshProUGUI Text_food_number_value;
    public TextMeshProUGUI Text_wood_number_value;
    public TextMeshProUGUI Text_stone_number_value;



    public Slider Slider_wood;
    public Slider Slider_food;
    public Slider Slider_stone;

    void Start()
    {
        //start recive
        StartCoroutine(Recive_resource());  
        
    }

   
    IEnumerator Recive_resource()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            Server_side.User_data.Recive_value_per_Values(new Server_side.Models.Req_recive_per_value { Password = "85245685", Username = "Hossyn" },
                result_per_value =>
                {

                }, result_value =>
                {
                    Text_wood_number_value.text = result_value.Wood.ToString();
                    Text_food_number_value.text = result_value.Food.ToString();
                    Text_stone_number_value.text = result_value.Stone.ToString();

                    //change slider value
                    Slider_food.value = result_value.Food;
                    Slider_wood.value = result_value.Wood;
                    Slider_stone.value = result_value.Stone;

                }, Storage =>
                {

                    //change slider max
                    Slider_food.maxValue = Storage;
                    Slider_wood.maxValue = Storage;
                    Slider_stone.maxValue = Storage;

                });

        }
    }

}
