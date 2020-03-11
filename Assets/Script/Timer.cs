using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float limitTime;
    bool game_End_Value;
    bool is_death_match;
    public UnityEngine.UI.Text text;
    public VectorManager vec_Man;
    public Player_Image_Sprite player_image_sprite;
    public Sprite deathmatch_Sprite;
    void Start()
    {
        is_death_match = false;
        limitTime = 30f;
        game_End_Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_End_Value) 
        { 
            limitTime -= Time.deltaTime;
            if (is_death_match)
            {
                if (limitTime < 0.1)
                    text.text = "0.0000";
                else
                    text.text = limitTime.ToString();
            }
            else 
                text.text = string.Format("{0:f0}", limitTime);
        }
        if (limitTime <= 0 && !is_death_match)
        {
            limitTime = 15f;
            vec_Man.change_Change();
            text.fontSize = 40;
            text.fontStyle = FontStyle.Bold;
            text.color = new Color(1, 0.25f, 0.25f, 1);
            is_death_match = true;
            transform.parent.GetComponent<UnityEngine.UI.Image>().sprite = deathmatch_Sprite;
        }

        if(limitTime < 0 && !game_End_Value)
        {
            TimeOver();
            game_End_Value = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameEnd(1,0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameEnd(1,1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            GameEnd(2, 6);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            GameObject.Find("Player_2_Vector").GetComponent<Player_2_Vector>().vector_y=80;
            */
    }

    public void GameEnd(int winner, int winning_state)
    {
        Debug.Log("GameEnd Called");
        game_End_Value = true;
        player_image_sprite.is_Game_Ended = true;
        /*
        UnityEngine.UI.Image temp;
        if (winner == 1)
            temp = GameObject.Find("Winner_1_Ending").GetComponent<UnityEngine.UI.Image>();
        else if (winner == 2)
            temp = GameObject.Find("Winner_2_Ending").GetComponent<UnityEngine.UI.Image>();
        else 
            temp = GameObject.Find("Draw_Ending").GetComponent<UnityEngine.UI.Image>();

        Color change_Alpha = temp.color;
        change_Alpha.a = 255f;
        temp.color = change_Alpha;
        */
        //승리자 정보 저장
        GameObject.Find("Save_data_during_Scene_Change").GetComponent<Save_Druring_Transition>().winner_data = winner;
        //1. 비기거나, 타임아웃 뜨면 EndingScene으로 넘어간다.
        if(winner == 0 || winning_state == 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
        //2. 누군가가 링 바깥으로 나가서 이겼으면 
            //a. Circle Gauage와 자식 오브젝트들, 타이머를 삭제한다.
        Destroy(GameObject.Find("CircleGauge"));
        //Destroy(gameObject.GetComponent<UnityEngine.UI.Text>());
        //b. 플레이어를 기울인다.
        switch (winning_state)
        {
            case 1:
            case 5:
            case 7:
            case 8:
                player_image_sprite.tilt_direction = 2;
                break;
            case 2:
            case 3:
            case 4:
            case 6:
                player_image_sprite.tilt_direction = 1;
                break;
            default:
                break;
        }
        //c. 기울여지는 것을 기다리고 EndingScene으로 넘어간다. 이 코드는 player_image_sprite쪽에 있음.
    }
    public void TimeOver()
    {
        GameEnd(vec_Man.winner_Decider(), 0);
    }

    /*
    public void moveToEndingScene(int winner, int winning_state)
    {
        //엔딩씬으로 넘어가는 코드 여기에 작성.
        Player_Image_Sprite winner_data = GameObject.Find("Player_Image_Sprite").GetComponent<Player_Image_Sprite>();
        winner_data.Set_Winner(winner);
        winner_data.Set_Win_State(winning_state); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
    }
    */
}
