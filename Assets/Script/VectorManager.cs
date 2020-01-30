﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VectorManager : MonoBehaviour
{

    public float click_Change = 1f;
    public float high_Click_Change = 0.7f;
    public float low_Click_Change = 1.3f;

    public GameObject player_Vector_1;
    public GameObject player_Vector_2;

    Player_1_Vector function_Reference_1;
    Player_2_Vector function_Reference_2;
    // Start is called before the first frame update
    void Start()
    {
        function_Reference_1 = player_Vector_1.GetComponent<Player_1_Vector>();
        function_Reference_2 = player_Vector_2.GetComponent<Player_2_Vector>();
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

    public void winner_checker()
    {
        float length_1 = function_Reference_1.vector_length();
        float length_2 = function_Reference_2.vector_length();
        if(length_1 > 180f)
        {
            //1이 이겼다는 내용과 함께 게임종료 함수를 호출
        }
        if (length_2 > 180f)
        {
            // 2가 이겼다는 내용과 함께 게임종료 함수 호출
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
}
