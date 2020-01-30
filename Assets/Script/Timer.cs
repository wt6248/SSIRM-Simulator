using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    float limitTime;
    bool game_End_Value;
    bool game_30s_Value;
    public UnityEngine.UI.Text text;
    public VectorManager vec_Man;
    
    void Start()
    {
        limitTime = 90f;
        game_End_Value = false;
        game_30s_Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        limitTime -= Time.deltaTime;
        text.text = " " + limitTime;

        if(limitTime < 30 && !game_30s_Value)
        {
            vec_Man.change_Change();
            game_30s_Value = true;
        }

        if(limitTime < 0 && !game_End_Value)
        {
            int winner = vec_Man.winner_Decider();
            game_End_Value = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameEnd(1);
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
}
