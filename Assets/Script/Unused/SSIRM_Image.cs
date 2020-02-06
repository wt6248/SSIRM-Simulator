using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 현재 사용되지 않는 코드입니다.
 * 이미지를 담을 자식 오브젝트들과 그것들을 분류해줄 부모 오브젝트가 필요합니다.
 * 그리고 기존에 알파값을 0으로 초기화해 둬야합니다.
 */

public class SSIRM_Image : MonoBehaviour
{
    public GameObject idleImageParent;                  //각 이미지 오브젝트를 담을 부모 오브젝트 (이미지 별로 분류 필요)
    public GameObject danger1ImageParent;               //인스펙터에서 직접 할당해 주어야 하고, 자식 오브젝트를 순서대로 배열해야함
    public GameObject danger2ImageParent;
    public GameObject over1ImageParent;
    public GameObject over2ImageParent;

    VectorManager vectorManager;
    Player_1_Vector function_Reference_1;
    Player_2_Vector function_Reference_2;
    Image current_image;                    //현재 표시 중인 이미지
    Image[] idleImages;                     //이미지 컴포넌트 리스트
    Image[] danger1Images;
    Image[] danger2Images;
    Image[] over1Images;
    Image[] over2Images;

    float length_1;
    float length_2;     //플레이어 1과 2의 벡터 길이
    float angle;        //현재 이기고 있는 플레이어의 벡터 각도

    int current_winner;     //현재 이기고 있는 플레이어
    int angle_case;         //각도 별 case

    bool gameEnded;         //게임 종료 여부

    void Start()
    {
        length_1 = 0f;
        length_2 = 0f;
        angle = 0f;
        current_winner = 0;
        angle_case = 0;
        gameEnded = false;
        vectorManager = GameObject.Find("VectorManager").GetComponent<VectorManager>();
        function_Reference_1 = vectorManager.player_Vector_1.GetComponent<Player_1_Vector>();
        function_Reference_2 = vectorManager.player_Vector_2.GetComponent<Player_2_Vector>();

        idleImages = idleImageParent.GetComponentsInChildren<Image>();
        idleImages[0].color = new Color(255f, 255f, 255f, 255f);

        danger1Images = danger1ImageParent.GetComponentsInChildren<Image>();
        danger2Images = danger2ImageParent.GetComponentsInChildren<Image>();
        over1Images = over1ImageParent.GetComponentsInChildren<Image>();
        over2Images = over2ImageParent.GetComponentsInChildren<Image>();

        current_image = idleImages[0];
    }

    void Update()
    {
        if (gameEnded == true)
            return;

        length_1 = function_Reference_1.vector_length();
        length_2 = function_Reference_2.vector_length();

        if (length_1 < 140f && length_2 < 140f)
        {
            ShowIdleImage();
        }
        else
        {
            if (length_1 > length_2)            //현재 승자 확인
            {
                current_winner = 1;
                angle = function_Reference_1.vector_Angle() * Mathf.Rad2Deg;
            }
            else if (length_1 < length_2)
            {
                current_winner = 2;
                angle = function_Reference_2.vector_Angle() * Mathf.Rad2Deg;
            }
            else
            {
                ShowIdleImage();              //동점일 경우 대치 상태 이미지 표시
                return;
            }

            angle_case = GetAngleCase(angle);

            if (length_1 >= 180f || length_2 >= 180f)
            {
                if (gameEnded == false)
                {
                    ShowOverImage(current_winner, angle_case);
                    gameEnded = true;
                    return;
                }
            }
            else
            {
                ShowDangerImage(current_winner, angle_case);
            }
        }

        return;
    }

    public void ShowIdleImage()     //대치 상태 이미지 표시
    {
        Image temp_image = idleImages[0];
        ChangeImage(temp_image);
    }

    public void ShowDangerImage(int current_winner, int angle_case)     //위험 상태 이미지 표시
    {
        Image temp_image = null;
        switch (current_winner)
        {
            case 1:
                temp_image = danger1Images[angle_case];
                break;
            case 2:
                temp_image = danger2Images[angle_case];
                break;
        }
        ChangeImage(temp_image);
    }

    public void ShowOverImage(int current_winner, int angle_case)   //게임 오버 이미지 표시
    {
        Image temp_image = null;
        switch (current_winner)
        {
            case 1:
                temp_image = over1Images[angle_case];
                break;
            case 2:
                temp_image = over2Images[angle_case];
                break;
        }
        ChangeImage(temp_image);
    }

    public void ChangeImage(Image temp_image)   //이미지 표시 전환 함수
    {
        if (temp_image == null)
        {
            Debug.LogError("Can't find image");
            return;
        }

        if (temp_image.color.a == 0)        //켜야할 이미지가 꺼져있는 경우 (아니면 그냥 두면 됨)
        {
            Color change_Alpha;
            change_Alpha = current_image.color;
            change_Alpha.a = 0f;
            current_image.color = change_Alpha;     //기존 이미지를 끄고

            change_Alpha = temp_image.color;
            change_Alpha.a = 255f;
            temp_image.color = change_Alpha;        //새 이미지를 킴

            current_image = temp_image;
        }
        return;
    }

    public int GetAngleCase(float angle)            //원을 8등분하여 오른쪽 = 0, 오른쪽 위 = 1, ... , 오른쪽 아래 = 7
    {
        if (angle < 0)
            angle += 360f;
        angle = (angle + 22.5f) % 360f;

        return (int)(angle / 45f) % 8;
    }
}
