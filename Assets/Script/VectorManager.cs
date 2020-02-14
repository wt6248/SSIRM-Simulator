using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VectorManager : MonoBehaviour
{

    public float click_Change;
    public float high_Click_Change;
    public float low_Click_Change;
    public float winning_length;
    public float change_length;

    public Player_1_Vector function_Reference_1;
    public Player_2_Vector function_Reference_2;

    Player_Image_Sprite winner_data;
    Timer temp_timer;

    // Start is called before the first frame update
    void Start()
    {
        winner_data = GameObject.Find("Player_Image_Sprite").GetComponent<Player_Image_Sprite>();
        temp_timer = GameObject.Find("Timer").GetComponent<Timer>();

        click_Change = 1f;
        high_Click_Change = 1.3f;
        low_Click_Change = 0.7f;
        winning_length = 90;
        change_length = 30;
}

    // Update is called once per frame
    void Update()
    {
        winner_checker();
    }

    public void change_Change()
    {
        click_Change *= 1.5f;
        high_Click_Change *= 1.5f;
        low_Click_Change *= 1.5f;
    }

    //테스트 안함.
    public void winner_checker()
    {
        float length_1 = function_Reference_1.vector_length();
        float length_2 = function_Reference_2.vector_length();

        if(length_1 > winning_length)
        {
            temp_timer.GameEnd(1, winner_data.get_game_state());
        }
        if (length_2 > winning_length)
        {
            temp_timer.GameEnd(2, winner_data.get_game_state());
        }
    }

    public int winner_Decider()
    {
        float length_1 = function_Reference_1.vector_length();
        float length_2 = function_Reference_2.vector_length();

        if (length_1 > length_2)
        {
            return 1;
        }
        else if (length_2 > length_1)
        {
            return 2;
        }
        else
            return 0;
    }

    public Color what_Circle_Color()
    {
        float length_1 = function_Reference_1.vector_length();
        float length_2 = function_Reference_2.vector_length();

        float temp_a = 0.6f / (change_length - winning_length);
        float temp_b = 0.4f - winning_length * temp_a;

        float temp_color_number1 = temp_a * length_1 + temp_b;
        float temp_color_number2 = temp_a * length_2 + temp_b;

        
        if (length_1< change_length && length_2< change_length)
        {
            //흰색 원 출력
            return new Color(1, 1, 1, 0.5f);
        }
        else if (length_1 > change_length)
        {
            if(length_2 > length_1)
            {
                //파란 샅바 출력
                return new Color(temp_color_number2, temp_color_number2, 1, 0.5f);
            }
            else{
                //빨간 샅바 출력
                return new Color(255, temp_color_number1, temp_color_number1, 0.5f);
            }
        }
        else
        {
            //파란 샅바 출력
            return new Color(temp_color_number2, temp_color_number2, 1, 0.5f);
        }
    }
}
