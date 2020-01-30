using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_Vector : MonoBehaviour
{
    // Start is called before the first frame update

    public float vector_x;
    public float vector_y;

    public GameObject vector_Manager;
    VectorManager change_reference;

    Player_2_Vector vector_Rerference;

    Vector3 starting_Position;
    void Start()
    {
        vector_x = 0f;
        vector_y = 0f;
        change_reference = vector_Manager.GetComponent<VectorManager>();
        vector_Rerference = GameObject.Find("Player_2_Vector").GetComponent<Player_2_Vector>();
        starting_Position = this.transform.position;

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
            //if(vector_x > 0)
            //{
            //    vector_x -= change_reference.click_Change;
            //}
            //else
            if (vector_Rerference.vector_x < 0)
            {
                if (vector_Rerference.vector_x < -140)
                    vector_Rerference.vector_x += change_reference.high_Click_Change;
                else
                    vector_Rerference.vector_x += change_reference.click_Change;
            }
            else
            {
                if (vector_x < -140)
                    vector_Rerference.vector_x -= change_reference.low_Click_Change;
                else
                    vector_x -= change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //if (vector_x < 0)
            //{
            //    vector_x += change_reference.click_Change;
            //}
            //else 
            if (vector_Rerference.vector_x > 0)
            {
                if (vector_Rerference.vector_x > 140)
                    vector_Rerference.vector_x -= change_reference.high_Click_Change;
                else
                    vector_Rerference.vector_x -= change_reference.click_Change;
            }
            else
            {
                if (vector_x > 140)
                    vector_Rerference.vector_x += change_reference.low_Click_Change;
                else
                    vector_x += change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //if (vector_y < 0)
            //{
            //    vector_y += change_reference.click_Change;
            //}
            //else 
            if (vector_Rerference.vector_y > 0)
            {
                if (vector_Rerference.vector_y > 140)
                    vector_Rerference.vector_y -= change_reference.high_Click_Change;
                else
                    vector_Rerference.vector_y -= change_reference.click_Change;
            }
            else
            {
                if (vector_y > 140)
                    vector_Rerference.vector_y += change_reference.low_Click_Change;
                else
                    vector_y += change_reference.click_Change;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //if (vector_y > 0)
            //{
            //    vector_y -= change_reference.click_Change;
            //}
            //else 
            if (vector_Rerference.vector_y < 0)
            {
                if (vector_Rerference.vector_y < -140)
                    vector_Rerference.vector_y += change_reference.high_Click_Change;
                else
                    vector_Rerference.vector_y += change_reference.click_Change;
            }
            else
            {
                if (vector_y < -140)
                    vector_Rerference.vector_y -= change_reference.low_Click_Change;
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
        float temp = Mathf.Atan2(vector_y, vector_x) * Mathf.Rad2Deg;
        float scale = vector_length()/20;
        float x_trans = Mathf.Cos(Mathf.Atan2(vector_y, vector_x)) * scale * 4;
        float Y_trans = Mathf.Sin(Mathf.Atan2(vector_y, vector_x)) * scale * 4;
        transform.position = new Vector3(x_trans, Y_trans, 0f) + starting_Position;
        transform.rotation = Quaternion.Euler(0,0,temp);
        transform.localScale = new Vector3(scale, scale, 0);

    }
}
