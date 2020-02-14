using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Pose : MonoBehaviour
{
    public Sprite startPose;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangePose());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ChangePose()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        transform.GetComponent<SpriteRenderer>().sprite = startPose;
    }
}
