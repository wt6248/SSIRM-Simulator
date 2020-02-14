using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite player_1_win;
    public Sprite player_2_win;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void player_1_win_sprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = player_1_win;
    }
    public void player_2_win_sprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = player_2_win;
    }
}
