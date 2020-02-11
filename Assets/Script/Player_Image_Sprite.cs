using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Image_Sprite : MonoBehaviour
{
    SpriteRenderer my_SpriteRender;
    public Animator animator;

    Player_1_Vector vector_1;
    Player_2_Vector vector_2;


    void Start()
    {
        //mySprites = new Sprite[12];
        //mySprites = Resources.LoadAll<Sprite>("players");
        my_SpriteRender = gameObject.GetComponent<SpriteRenderer>();
        my_SpriteRender.color = new Color(255,255,255,255);
        vector_1 = GameObject.Find("Player_1_Vector").GetComponent<Player_1_Vector>();
        vector_2 = GameObject.Find("Player_2_Vector").GetComponent<Player_2_Vector>();
    }

    // Update is called once per frame
    void Update()
    {
        get_game_state();
    }

    public void Show_Image()
    {
        my_SpriteRender.color = new Color(255, 255, 255, 0);
    }
    public void Change_Spirte_image_1()
    {
//        my_SpriteRender.sprite = my_SpriteRender.sprite[1];
    }

    void get_game_state()
    {
        float vector_1_angle = vector_1.vector_Angle() * Mathf.Rad2Deg;
        float vector_2_angle = vector_2.vector_Angle() * Mathf.Rad2Deg;
        float vector_1_length = vector_1.vector_length();
        float vector_2_length = vector_2.vector_length();


        if (vector_1_length > 140 && vector_1_length > vector_2_length)
        {
            if (vector_1_angle < 45 && vector_1_angle >= -45)
                animator.SetInteger("Attack_state", 1);
            else if (vector_1_angle >= 45 && vector_1_angle < 135)
                animator.SetInteger("Attack_state", 3);
            else if (vector_1_angle >= 135 || vector_1_angle < -135)
                animator.SetInteger("Attack_state", 2);
            else if (vector_1_angle >= -135 && vector_1_angle < -45)
                animator.SetInteger("Attack_state", 4);
        }
        else if (vector_2_length > 140 && vector_2_length > vector_1_length)
        {
            if (vector_2_angle < 45 && vector_2_angle >= -45)
                animator.SetInteger("Attack_state", 5);
            else if (vector_2_angle >= 45 && vector_2_angle < 135)
                animator.SetInteger("Attack_state", 7);
            else if (vector_2_angle >= 135 || vector_2_angle < -135)
                animator.SetInteger("Attack_state", 6);
            else if (vector_2_angle >= -135 && vector_2_angle < -45)
                animator.SetInteger("Attack_state", 8);
        }
        else if (vector_1_length > 180)
        {
            animator.SetInteger("Attack_state", 9);
        }
        else if (vector_2_length > 180)
        {
            animator.SetInteger("Attack_state", 10);
        }
        else
        {
            animator.SetInteger("Attack_state", 0);
        }
    }
}
