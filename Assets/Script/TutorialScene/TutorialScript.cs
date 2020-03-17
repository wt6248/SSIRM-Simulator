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
    // Start is called before the first frame update
    void Start()
    {
        TutorialState = 0;
        tutorial_8_reseted = false;
        tutorial_9_reseted = false;
        ring_whole.SetActive(false);
        key_explanation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("getScript_" + TutorialState.ToString(), 0f);
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
        if(TutorialState < 13)
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
        tutorial_explanation.text = "선수의 다리나 상체에 힘을 실으면 씨름 기술이 써지지.";
    }
    void getScript_3()
    {
        ring_whole.SetActive(true);
        tutorial_explanation.text = "각 선수는 방향키를 연타하는 것으로 신체의 각 부위에 힘을 줄 수 있다.\n" +
                                    "자기가 준 힘의 정도는 이 씨름판의 화살표로 알 수 있지.\n" +
                                    "화살표가 씨름판을 넘어갈 정도로 힘을 주면, 기술을 발동하면서 상대방을 제압할 수 있다.";
    }
    void getScript_4()
    {
        key_explanation.SetActive(true);
        tutorial_explanation.text = "각 방향키는 밀기, 당기기, 왼다리, 오른다리에 일치한다.\n" +
                                    "1번 선수 홍샅바는 W, S, A, D를 연타하는 것으로 힘을 줄 수 있고,\n" +
                                    "2번 선수 청샅바는 위, 아래, 왼쪽 오른쪽 방향키를 연타하는 것으로 힘을 줄 수 있다.";
    }
    void getScript_5()
    {
        tutorial_explanation.text = "자유롭게 입력해서 한번 확인해보도록. \n" +
                                    "1번 선수 홍샅바의 화살표가 씨름판을 넘어가도록 해봐라.";

        vectorManageScript.vector_1_enabled = true;
        vectorManageScript.vector_2_enabled = false;
        vectorManageScript.reset_game_p2();

        if (vectorManageScript.check_winning() == 1)
            TutorialState += 1;
    }
    void getScript_6()
    {
        tutorial_explanation.text = "이번엔 2번 선수 청샅바가 화살표가 씨름판을 넘어가도록 해봐라.";

        vectorManageScript.vector_1_enabled = false;
        vectorManageScript.vector_2_enabled = true;
        vectorManageScript.reset_game_p1();

        if (vectorManageScript.check_winning() == 2)
            TutorialState += 1;
    }
    void getScript_7()
    {
        vectorManageScript.reset_game();
        tutorial_explanation.text = "화살표가 씨름판 바깥으로 나가면, 기술이 발동해서 상대방을 넘어트릴 수 있다.\n" +
                                    "상대방 화살표 방향의 키를 입력해서, 상대방의 힘(화살표)을 빼는 것으로 방어할 수 있다.";
        tutorial_8_reseted = false;
    }
    void getScript_8()
    {
        tutorial_explanation.text = "1번 선수 홍샅바가, 상대방의 공격을 방어해서 상대방의 화살표를 0으로 없애보도록.";

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
        tutorial_explanation.text = "이번에는 2번 선수 청샅바가, 상대방의 공격을 방어해서 상대방의 화살표를 없애보도록.";
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
        tutorial_explanation.text = "지금까지 알려준대로 공격과 방어를 통해, 상대방을 넘어트리면 승리를 가질 수 있다.\n" +
                                    "자신의 화살표가 클수록, 상대방의 방어력이 더 커져서, 한번에 올리기 힘들지.";
    }
    void getScript_11()
    {
        tutorial_explanation.text = "시간이 0이 되면 데스매치가 된다. 추가 시간이 주어지고, 더 강력하게 공격할 수 있지.\n" +
                                    "추가 시간 동안에도 승부를 보지 못하면, 힘을 더 많이 가한 사람이 판정 승을 챙긴다.";
    }

    void getScript_12()
    {
        tutorial_explanation.text = "노력을 통해 승리를 쟁취하도록. (다음 버튼 클릭시, 타이틀 화면으로 돌아갑니다.)";
    }

    void getScript_13()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
