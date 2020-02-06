using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Game_Start : MonoBehaviour
{
    public UnityEngine.UI.Image countdown_Image;
    public Sprite image_2;
    public Sprite image_1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void game_start()
    {
        //3을 화면에 띄우는 함수. + 소리 효과.
        countdown_Image.color = new Color(255, 255, 255, 255);
        GetComponent<AudioSource>().Play();

        //1초 지연
        Invoke("delay_function", 1);

        //2를 화면에 띄우는 함수. + 소리 효과. 
        countdown_Image.sprite = image_2;
        GetComponent<AudioSource>().Play();

        //1초 지연
        Invoke("delay_function", 1);

        //1를 화면에 띄우는 함수. + 소리 효과.
        countdown_Image.sprite = image_1;
        GetComponent<AudioSource>().Play();

        //1초 지연
        Invoke("delay_function", 1);

        //Time.TimeScale = 1 하고, 스타트 브금 틀어주고, 버튼 자기자신 삭제.
        //스타트 브금 시작 코드 작성.
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        countdown_Image.color = new Color(255, 255, 255, 0);
        Destroy(gameObject);
    }

    void delay_function()
    {
        Debug.Log("delay_function called");
    }
}
