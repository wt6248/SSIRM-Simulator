using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Vector : MonoBehaviour
{
    // Start is called before the first frame update

    public float vector_x;
    public float vector_y;
    public VectorManager change_reference;

    Player_2_Vector opponent_2_Vector;
    RectTransform this_RectTransform;
    //Vector3 starting_Position;
    void Start()
    {
        vector_x = 0f;
        vector_y = 0f;
        opponent_2_Vector = GameObject.Find("Player_2_Vector").GetComponent<Player_2_Vector>();
        //starting_Position = this.transform.position;
        this_RectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        change_vector();
        make_transform_from_vectors();
    }

    void change_vector()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            GetComponent<AudioSource>().Play();
            if(vector_x > 0)
            {
                vector_x -= change_reference.click_Change;
            }
            else
            if (opponent_2_Vector.vector_x < 0)
            {
                if (opponent_2_Vector.vector_x < -change_reference.change_length)
                    opponent_2_Vector.vector_x += change_reference.high_Click_Change;
                else
                    opponent_2_Vector.vector_x += change_reference.click_Change;
            }
            else
            {
                if (vector_x < -change_reference.change_length)
                    vector_x -= change_reference.low_Click_Change;
                else
                    vector_x -= change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            //효과음 파트
            GetComponent<AudioSource>().Play();

            if (vector_x < 0)
            {
                vector_x += change_reference.click_Change;
            }
            else 
            if (opponent_2_Vector.vector_x > 0)
            {
                if (opponent_2_Vector.vector_x > change_reference.change_length)
                    opponent_2_Vector.vector_x -= change_reference.high_Click_Change;
                else
                    opponent_2_Vector.vector_x -= change_reference.click_Change;
            }
            else
            {
                if (vector_x > change_reference.change_length) 
                { 
                    //Debug.Log("아주 조금 늘어날꺼야>");
                    //Debug.Log(change_reference.low_Click_Change);
                    vector_x += change_reference.low_Click_Change;
                }
                else
                    vector_x += change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            GetComponent<AudioSource>().Play();
            if (vector_y < 0)
            {
                vector_y += change_reference.click_Change;
            }
            else 
            if (opponent_2_Vector.vector_y > 0)
            {
                if (opponent_2_Vector.vector_y > change_reference.change_length)
                    opponent_2_Vector.vector_y -= change_reference.high_Click_Change;
                else
                    opponent_2_Vector.vector_y -= change_reference.click_Change;
            }
            else
            {
                if (vector_y > change_reference.change_length)
                    vector_y += change_reference.low_Click_Change;
                else
                    vector_y += change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<AudioSource>().Play();
            if (vector_y > 0)
            {
                vector_y -= change_reference.click_Change;
            }
            else 
            if (opponent_2_Vector.vector_y < 0)
            {
                if (opponent_2_Vector.vector_y < -change_reference.change_length)
                    opponent_2_Vector.vector_y += change_reference.high_Click_Change;
                else
                    opponent_2_Vector.vector_y += change_reference.click_Change;
            }
            else
            {
                if (vector_y < -change_reference.change_length)
                    vector_y -= change_reference.low_Click_Change;
                else
                    vector_y -= change_reference.click_Change;
            }
        }
    }

    public float vector_length()
    {
        return Mathf.Pow((Mathf.Pow(vector_x,2)+ Mathf.Pow(vector_y, 2)), 0.5f);
    }

    public float vector_Angle()
    {
        return Mathf.Atan2(vector_y, vector_x);
    }

    void make_transform_from_vectors()
    {
        /*
        //백터의 각도. rotation에 사용됨. x축을 기준으로 반시계 방향으로 회전, 360도를 잰다.
        float angle = vector_Angle() * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        //1클릭에 x축으로 1 늘어남. 승리 클릭 횟수(20으로 가정)만큼 클릭하면 백터 길이는 20이지만, scale은 0.4가 되게 하고 싶음.
        float scale = 0.4f / change_reference.winning_length * vector_length();
        transform.localScale = new Vector3(scale, scale, 0);

        //scale이 0.5면 추가 trans는 1.5, scale이 1이면 추가되어야 할 position은 3.
        float x_trans = Mathf.Cos(Mathf.Atan2(vector_y, vector_x)) * scale * 3;
        float Y_trans = Mathf.Sin(Mathf.Atan2(vector_y, vector_x)) * scale * 3;
        transform.position = new Vector3(x_trans, Y_trans, 0f) + starting_Position;
        */

        //코드가 수정됨.
        //1. transform 변수가 transform에서 rectTrasfrom으로 바뀜.
        //Rotation과 Scale만 바꾸면 된다. (pivot 조절로 가능해짐.)

        //백터 길이가 승리 길이일 때, scale이 1이면 된다.
        float scale = 1f / change_reference.winning_length * vector_length();
        this_RectTransform.localScale = new Vector3(scale, scale, 0);

        //백터 각도에 맞춰 Rotation을 돌린다.
        float angle = vector_Angle() * Mathf.Rad2Deg;
        this_RectTransform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
