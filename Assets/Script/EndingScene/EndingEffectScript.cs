    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingEffectScript : MonoBehaviour
{
    JudgeAnimation judge;
    int winner;
    // Start is called before the first frame update
    void Start()
    {
        winner = GameObject.Find("Save_data_during_Scene_Change").GetComponent<Save_Druring_Transition>().winner_data;
        //winner = 0;
        judge = GameObject.Find("Judge").GetComponent<JudgeAnimation>();

        StartCoroutine(endingSceneCorutine());
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(winner);
    }
    IEnumerator endingSceneCorutine()
    {
        yield return new WaitForSeconds(1);
        //1초 쉬었다가 심판이 승자 손을 듬.
        if (winner == 1)
            judge.player_1_win_sprite();
        if (winner == 2)
            judge.player_2_win_sprite();
        if (winner != 0)
        {
            //천하장사 만만세 브금이 나와야 함.
            GameObject.Find("MainBGM").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4);
        }

        //화면에 누가 이겼는지 알려주는 이미지 사용.
        GameObject.Find("GoToTitleButton").GetComponent<GoToTitleButton>().appearButton();
        WinnerImage winner_Image_function = GameObject.Find("WinnerImage").GetComponent<WinnerImage>();
        if (winner == 0)
            winner_Image_function.winner_draw();
        else if (winner == 1)
            winner_Image_function.winner_1();
        else if (winner == 2)
            winner_Image_function.winner_2();


    }
}
