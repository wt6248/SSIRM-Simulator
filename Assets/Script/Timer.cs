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
    
    void Start()
    {
        is_death_match = false;
        limitTime = 30f;
        game_End_Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!game_End_Value)
            limitTime -= Time.deltaTime;
        if (is_death_match)
            text.text = limitTime.ToString();
        else
            text.text = string.Format("{0:f0}", limitTime);

        if(limitTime < 0 && !is_death_match)
        {
            limitTime = 15f;
            vec_Man.change_Change();
            text.fontSize = 40;
            text.fontStyle = FontStyle.Bold;
            text.color = new Color(1, 0.25f, 0.25f, 1);
            is_death_match = true;
        }

        if(limitTime < 0 && !game_End_Value)
        {
            TimeOver();
            game_End_Value = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            moveToEndingScene();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameEnd(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            GameEnd(3);
    }

    public void GameEnd(int winner)
    {
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
    }
    public void TimeOver()
    {
        GameEnd(vec_Man.winner_Decider());
    }

    public void moveToEndingScene()
    {
        //엔딩씬으로 넘어가는 코드 여기에 작성.
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
    }
}
