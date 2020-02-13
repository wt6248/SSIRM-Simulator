using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Image_Sprite : MonoBehaviour
{
    //SpriteRenderer my_SpriteRender;
    public Animator animator;

    Player_1_Vector vector_1;
    Player_2_Vector vector_2;

    int gameWinner;
    int game_Winning_State;
    public bool is_Game_Ended;
    public int tilt_direction;
    bool end_Scene_Called;

    void Start()
    {
        is_Game_Ended = false;
        end_Scene_Called = false;
        tilt_direction = 0;
        //mySprites = new Sprite[12];
        //mySprites = Resources.LoadAll<Sprite>("players");
        //my_SpriteRender = gameObject.GetComponent<SpriteRenderer>();
        //my_SpriteRender.color = new Color(255,255,255,255);
        vector_1 = GameObject.Find("Player_1_Vector").GetComponent<Player_1_Vector>();
        vector_2 = GameObject.Find("Player_2_Vector").GetComponent<Player_2_Vector>();
    }

    // Update is called once per frame
    void Update()
    {
        //게임 종료시 작동되지 않도록 게임 종료 함수에 이 스크립트 bool을 바꾸도록 함.
        if(!is_Game_Ended)
            set_game_state();
        else
        {
            if (tilt_direction == 1)
                Tilt_Sprite_Clockwize_90deg();
            else if (tilt_direction == 2)
                Tilt_Sprite_Counterclockwize_90deg();
            if (end_Scene_Called)
                StartCoroutine(endingSceneDelayCall());
        }
    }

    IEnumerator endingSceneDelayCall()
    {
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
    }
    //public void Show_Image()
    //{
    //    my_SpriteRender.color = new Color(255, 255, 255, 0);
    //}
//    public void Change_Spirte_image_1()
//   {
//        my_SpriteRender.sprite = my_SpriteRender.sprite[1];
//    }

    public void Tilt_Sprite_Clockwize_90deg()
    {
       if(transform.rotation.z > -0.7071068f)
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }
        else
        {
            end_Scene_Called = true;
        }
    }

    public void Tilt_Sprite_Counterclockwize_90deg()
    {
        if (transform.rotation.z < 0.7071068f)
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            end_Scene_Called = true;
        }
    }

    /*public void Set_Winner(int winner)  
    { 
        is_Game_Ended = true;
        gameWinner = winner;
    }
    public void Set_Win_State(int win_state) 
    { 
        game_Winning_State = win_state; 
    }*/

    public void set_game_state()
    {
        float change_value =GameObject.Find("VectorManager").GetComponent<VectorManager>().change_length;
        int temp_Attack_State = 0;
        float vector_1_angle = vector_1.vector_Angle() * Mathf.Rad2Deg;
        float vector_2_angle = vector_2.vector_Angle() * Mathf.Rad2Deg;
        float vector_1_length = vector_1.vector_length();
        float vector_2_length = vector_2.vector_length();


        if (vector_1_length > change_value && vector_1_length > vector_2_length)
        {
            if (vector_1_angle < 45 && vector_1_angle >= -45)
                temp_Attack_State = 1;
            else if (vector_1_angle >= 45 && vector_1_angle < 135)
                temp_Attack_State = 3;
            else if (vector_1_angle >= 135 || vector_1_angle < -135)
                temp_Attack_State = 2;
            else if (vector_1_angle >= -135 && vector_1_angle < -45)
                temp_Attack_State = 4;
        }
        else if (vector_2_length > change_value && vector_2_length > vector_1_length)
        {
            if (vector_2_angle < 45 && vector_2_angle >= -45)
                temp_Attack_State = 5;
            else if (vector_2_angle >= 45 && vector_2_angle < 135)
                temp_Attack_State = 7;
            else if (vector_2_angle >= 135 || vector_2_angle < -135)
                temp_Attack_State = 6;
            else if (vector_2_angle >= -135 && vector_2_angle < -45)
                temp_Attack_State = 8;
        }
        else
        {
            temp_Attack_State = 0;
        }
        animator.SetInteger("Attack_state", temp_Attack_State);
    }

    public int get_game_state()
    {
        return animator.GetInteger("Attack_state");
    }
}
