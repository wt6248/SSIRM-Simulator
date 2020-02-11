using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdScript : MonoBehaviour
{
    bool movement;
    IEnumerator stop_move;
    // Start is called before the first frame update
    void Start()
    {
        movement = true;
        stop_move = UpDownMovement();
        StartCoroutine(stop_move);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stop_crowd_move()
    {
        StartCoroutine(stop_move);
    }

    IEnumerator UpDownMovement()
    {

        while (true)
        {
            Debug.Log("a");
            yield return new WaitForSeconds(1);
            if (movement)
            {
                transform.position += new Vector3(0, 0.3f, 0);
                movement = false;
            }
            else
            {
                transform.position -= new Vector3(0, 0.3f, 0);
                movement = true;
            }
        }
    }
}
