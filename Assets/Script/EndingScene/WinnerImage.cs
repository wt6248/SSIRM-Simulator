using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerImage : MonoBehaviour
{

    UnityEngine.UI.Image target;
    public Sprite image_player_1_win;
    public Sprite image_player_2_win;
    public Sprite image_Draw;

    public void winner_1()
    {
        target.color = new Color(1, 1, 1, 1);
        target.sprite = image_player_1_win;
    }
    public void winner_2()
    {
        target.color = new Color(1, 1, 1, 1);
        target.sprite = image_player_2_win;
    }
    public void winner_draw()
    {
        target.color = new Color(1, 1, 1, 1);
        target.sprite = image_Draw;
    }
    void Start()
    {
        target = GameObject.Find("WinnerImage").GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
