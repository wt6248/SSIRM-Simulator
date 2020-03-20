using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public UnityEngine.UI.Text tutorial_explanation;
    public GameObject ring_outside;
    public GameObject ring_inside;
    public GameObject ring_whole;
    public GameObject key_explanation;

    public VectorManageScript vectorManageScript;

    int TutorialState;
    bool tutorial_8_reseted;
    bool tutorial_9_reseted;
    string[] text_script_list;
    // Start is called before the first frame update
    void Start()
    {
        TutorialState = 0;
        tutorial_8_reseted = false;
        tutorial_9_reseted = false;
        ring_whole.SetActive(false);
        key_explanation.SetActive(false);
        text_script_list = new string[] { 
            "getScript_0", 
            "getScript_1",
            "getScript_2",
            "getScript_3",
            "getScript_3_1",
            "getScript_4",
            "getScript_4_1",
            "getScript_4_2",
            "getScript_5",
            "getScript_6",
            "getScript_7",
            "getScript_7_1",
            "getScript_8",
            "getScript_9",
            "getScript_10",
            "getScript_10_1",
            "getScript_11",
            "getScript_11_1",
            "getScript_12",
            "getScript_13"
        };
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("getScript_" + TutorialState.ToString(), 0f);
        Invoke(text_script_list[TutorialState], 0f);
    }

    public void down_Tutorial_state()
    {
        /*
        if (TutorialState == 5 || TutorialState == 6 || TutorialState == 8 || TutorialState == 9)
            TutorialState -= 1;
        else if(TutorialState > 1)
            TutorialState -= 2;
            */
        if(TutorialState > 0)
            TutorialState--;
    }
    public void Up_Tutorial_state()
    {
        /*
        if (TutorialState == 5 || TutorialState == 6 || TutorialState == 8 || TutorialState == 9)
            TutorialState++;
            */
        if(TutorialState < 20)
            TutorialState++;
    }

    void getScript_0()
    {
        tutorial_explanation.text = "안녕하시오. 나는 심판이다.\n(다음 버튼을 눌러 진행하세요.)";
    }

    void getScript_1()
    {
        tutorial_explanation.text = "SSIRM은 다리 걸기, 들어올리기 등을 통해 상대를 넘어뜨리는 씨름 게임이다.";
    }
    void getScript_2()
    {
        tutorial_explanation.text = "선수의 다리나 상체에 힘을 실으면 씨름 기술이 써지지.\n";
    }
    void getScript_3()
    {
        ring_whole.SetActive(true);
        tutorial_explanation.text = "각 선수는 방향키를 연타하는 것으로 신체의 각 부위에 힘을 줄 수 있다. 그 것이 씨름판의 화살표지.";
    }
    void getScript_3_1()
    {
        ring_whole.SetActive(true);
        tutorial_explanation.text = "화살표가 씨름판을 넘어갈 정도로 방향키를 연타, 힘을 주면, 기술을 발동하면서 상대방을 제압할 수 있다.";
    }

    void getScript_4()
    {
        key_explanation.SetActive(true);
        tutorial_explanation.text = "각 방향키는 밀기, 당기기, 왼다리, 오른다리에 일치한다. 잠시 자유롭게 눌러봐라.";
    }
    void getScript_4_1()
    {
        tutorial_explanation.text = "1번 선수 홍샅바는 W, S, A, D를 연타하는 것으로 힘을 줄 수 있다.";
    }
    void getScript_4_2()
    {
        tutorial_explanation.text = "2번 선수 청샅바는 위, 아래, 왼쪽 오른쪽 방향키를 연타하는 것으로 힘을 줄 수 있다.";
    }

    void getScript_5()
    {
        tutorial_explanation.text = "먼저 1번 선수 홍샅바가 자유롭게 입력해서 화살표가 씨름판을 넘어가도록 해봐라.";

        vectorManageScript.vector_1_enabled = true;
        vectorManageScript.vector_2_enabled = false;
        vectorManageScript.reset_game_p2();

        if (vectorManageScript.check_winning() == 1)
            TutorialState += 1;
    }
    void getScript_6()
    {
        tutorial_explanation.text = "이번엔 2번 선수 청샅바가 자유롭게 입력해서 화살표가 씨름판을 넘어가도록 해봐라.";

        vectorManageScript.vector_1_enabled = false;
        vectorManageScript.vector_2_enabled = true;
        vectorManageScript.reset_game_p1();

        if (vectorManageScript.check_winning() == 2)
            TutorialState += 1;
    }
    void getScript_7()
    {
        vectorManageScript.reset_game();
        tutorial_explanation.text = "공격뿐만 아니라 방어 또한 승리의 전략중 하나이다.\n";
        tutorial_8_reseted = false;
    }
    void getScript_7_1()
    {
        tutorial_explanation.text = "상대방과 동일한 방향의 힘을 줌으로써, 상대방의 힘(화살표)을 뺄 수 있다.";
 
    }
    void getScript_8()
    {
        tutorial_explanation.text = "1번 선수 홍샅바가, 청샅바의 화살표와 동일한 방향으로 입력해, 힘(화살표)를 없애보도록.";

        if (!tutorial_8_reseted)
        {
            vectorManageScript.reset_game_2();
            tutorial_8_reseted = true;
        }
        vectorManageScript.vector_1_enabled = true;
        vectorManageScript.vector_2_enabled = false;
        tutorial_9_reseted = false;

        if (vectorManageScript.check_p2_length_0())
            TutorialState += 1;
    }
    void getScript_9()
    {
        tutorial_explanation.text = "2번 선수 청샅바가, 홍샅바의 화살표와 동일한 방향으로 입력해, 힘(화살표)를 없애보도록.";
        if (!tutorial_9_reseted)
        {
            vectorManageScript.reset_game_3();
            tutorial_9_reseted = true;
        }
        vectorManageScript.vector_1_enabled = false;
        vectorManageScript.vector_2_enabled = true;
        tutorial_8_reseted = false;

        if (vectorManageScript.check_p1_length_0())
            TutorialState += 1;
    }
    void getScript_10()
    {
        vectorManageScript.vector_1_enabled = true;
        tutorial_9_reseted = false;
        vectorManageScript.reset_game();
        tutorial_explanation.text = "자신의 화살표가 클수록, 상대방의 방어에 취약해진다. 즉 화살표가 더 많이 줄어들지. 염두에 두도록.";
    }
    void getScript_10_1()
    {
        tutorial_explanation.text = "지금까지 알려준대로 공격과 방어를 통해, 상대방을 넘어트리면 승리를 가질 수 있다.";
    }

    void getScript_11()
    {
        tutorial_explanation.text = "만약 시간이 0이 되도록 넘어트리지 못하면, 추가 시간이 주어진다.\n" ;
    }
    void getScript_11_1()
    {
        tutorial_explanation.text = "추가 시간 동안에도 승부를 보지 못하면, 마지막에 힘을 더 많이 가한 사람이 판정 승을 챙긴다.";
    }

    void getScript_12()
    {
        tutorial_explanation.text = "노력을 통해 승리를 쟁취하도록.\n(다음 버튼 클릭시, 타이틀로 돌아갑니다.)";
    }

    void getScript_13()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
