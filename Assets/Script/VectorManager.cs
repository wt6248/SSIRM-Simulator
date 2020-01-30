using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VectorManager : MonoBehaviour
{

    public float click_Change = 1f;
    public float high_Click_Change = 0.7f;
    public float low_Click_Change = 1.3f;

    public GameObject player_Vector_1;
    public GameObject player_Vector_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_Change()
    {
        click_Change *= 1.5f;
        high_Click_Change *= 1.5f;
        low_Click_Change *= 1.5f;
    }
}
