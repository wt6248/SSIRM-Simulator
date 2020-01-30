using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Vector : MonoBehaviour
{
    // Start is called before the first frame update

    float vector_x;
    float vector_y;
    public GameObject vector_Manager;
    VectorManager change_reference;
    void Start()
    {
        vector_x = 0f;
        vector_y = 0f;
        change_reference = vector_Manager.GetComponent<VectorManager>();

    }

    // Update is called once per frame
    void Update()
    {
        change_vector();
        make_transform_from_vectors();
    }

    void change_vector()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vector_x -= change_reference.click_Change;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            vector_x += change_reference.click_Change;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vector_y += change_reference.click_Change;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vector_y -= change_reference.click_Change;
        }
    }

    public float vector_length()
    {
        return Mathf.Pow((Mathf.Pow(vector_x, 2) + Mathf.Pow(vector_y, 2)), 0.5f);
    }

    void make_transform_from_vectors()
    {
        float temp = Mathf.Atan2(vector_y, vector_x) * Mathf.Rad2Deg;
        float scale = vector_length() / 20;
        float x_trans = Mathf.Cos(Mathf.Atan2(vector_y, vector_x)) * scale * 4;
        float Y_trans = Mathf.Sin(Mathf.Atan2(vector_y, vector_x)) * scale * 4;
        transform.position = new Vector3(x_trans, Y_trans, 0f);
        transform.rotation = Quaternion.Euler(0, 0, temp);
        transform.localScale = new Vector3(scale, scale, 0);

    }
}
