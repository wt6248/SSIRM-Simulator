using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorManageScript : MonoBehaviour
{
    float vector_1_x;
    float vector_1_y;
    float vector_2_x;
    float vector_2_y;
    public RectTransform vector_1;
    public RectTransform vector_2;
    public bool vector_1_enabled;
    public bool vector_2_enabled;


    // Start is called before the first frame update
    void Start()
    {
        vector_1_x = 0;
        vector_1_y = 0;
        vector_2_x = 0;
        vector_2_y = 0;
        vector_1_enabled = true;
        vector_2_enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (vector_1_enabled)
            vector_1_input();
        make_transform_from_vectors(vector_1, vector_1_x, vector_1_y);
 
        if (vector_2_enabled)
            vector_2_input();
        make_transform_from_vectors(vector_2, vector_2_x, vector_2_y);
    }

    void vector_1_input()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (vector_2_x < 0)
                vector_2_x += 1;
            else vector_1_x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (vector_2_x > 0)
                vector_2_x -= 1;
            else vector_1_x += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (vector_2_y < 0)
                vector_2_y += 1;
            else vector_1_y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (vector_2_y > 0)
                vector_2_y -= 1;
            else vector_1_y += 1;
        }
    }
    void vector_2_input()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (vector_1_x < 0)
                vector_1_x += 1;
            else vector_2_x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (vector_1_x > 0)
                vector_1_x -= 1;
            else vector_2_x += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (vector_1_y < 0)
                vector_1_y += 1;
            else vector_2_y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (vector_1_y > 0)
                vector_1_y -= 1;
            else vector_2_y += 1;
        }
    }

    public float vector_length(float vector_x, float vector_y)
    {
        return Mathf.Pow((Mathf.Pow(vector_x, 2) + Mathf.Pow(vector_y, 2)), 0.5f);
    }

    public float vector_Angle(float vector_x, float vector_y)
    {
        return Mathf.Atan2(vector_y, vector_x);
    }

    void make_transform_from_vectors(RectTransform Target_Vector, float vector_x, float vector_y)
    {
        //백터 길이가 승리 길이일 때, scale이 1이면 된다.
        float scale = 1f / 20 * vector_length(vector_x, vector_y);
        Target_Vector.localScale = new Vector3(scale, scale, 0);

        //백터 각도에 맞춰 Rotation을 돌린다.
        float angle = vector_Angle(vector_x, vector_y) * Mathf.Rad2Deg;
        Target_Vector.rotation = Quaternion.Euler(0, 0, angle);

    }

    public int check_winning()
    {
        if (vector_length(vector_1_x, vector_1_y) >= 20)
            return 1;
        if (vector_length(vector_2_x, vector_2_y) >= 20)
            return 2;
        return 0;
    }
    public bool check_p1_length_0()
    {
        if (vector_1_x == 0 && vector_1_y == 0)
            return true;
        return false;
    }
    public bool check_p2_length_0()
    {
        if (vector_2_x == 0 && vector_2_y == 0)
            return true;
        return false;
    }

    public void reset_game()
    {
        vector_1_x = 0;
        vector_1_y = 0;
        vector_2_x = 0;
        vector_2_y = 0;
    }
    public void reset_game_p1()
    {
        vector_1_x = 0;
        vector_1_y = 0;
    }
    public void reset_game_p2()
    {
        vector_2_x = 0;
        vector_2_y = 0;
    }
    public void reset_game_2()
    {
        vector_1_x = 0;
        vector_1_y = 0;
        vector_2_x = 10;
        vector_2_y = 10;
    }
    public void reset_game_3()
    {
        vector_1_x = 10;
        vector_1_y = 10;
        vector_2_x = 0;
        vector_2_y = 0;
    }
}
