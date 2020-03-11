using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public UnityEngine.UI.Text tutorial_explanation;
    public GameObject ring_outside;
    public GameObject ring_inside;

    int TutorialState;
    // Start is called before the first frame update
    void Start()
    {
        TutorialState = 0;
        ring_outside.SetActive(false);
        ring_inside.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TutorialState += 1;
            Invoke("getScript_" + TutorialState.ToString(), 0f);
        }


    }

    void getScript_0()
    {
        tutorial_explanation.text = "디버그용 메세지. ";
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
        tutorial_explanation.text = "방향키(W,A,S,D 혹은 위,아래,왼쪽,오른쪽)를 연타하는 것으로 해당 부위에 힘을 줄 수 있다.";
    }
    void getScript_4()
    {
        ring_outside.SetActive(true);
        ring_inside.SetActive(true);
        tutorial_explanation.text = "자기가 준 힘의 정도는 이 씨름판의 화살표로 알 수 있지.";
    }
    void getScript_5()
    {
        tutorial_explanation.text = "화살표가 씨름판 바깥으로 나가면, 기술이 발동해서 상대방을 넘어트릴 수 있다.";
    }
    void getScript_6()
    {
        tutorial_explanation.text = "다만, 상대방 화살표 방향의 키를 입력해서, 상대방의 힘(화살표)을 빼는 것으로 방어할 수 있다.";
    }
    void getScript_7()
    {
        tutorial_explanation.text = "공격과 방어를 통해, 상대방을 넘어트리면 승리를 가질 수 있다.";
    }
    void getScript_8()
    {
        tutorial_explanation.text = "시간이 0이 되면 데스매치가 된다. 추가 시간이 주어지고, 더 강력하게 공격할 수 있지. \n추가 시간 동안에도 승부를 보지 못하면, 힘을 더 많이 가한 사람이 판정 승을 챙긴다.";
    }

    void getScript_9()
    {
        tutorial_explanation.text = "노력을 통해 승리를 쟁취하도록. (마우스 왼쪽 버튼 클릭시, 타이틀 화면으로 돌아갑니다.)";
    }

    void getScript_10()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
