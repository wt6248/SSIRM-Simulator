using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Game_Start : MonoBehaviour
{
    public UnityEngine.UI.Image countdown_Image;
    public Sprite image_2;
    public Sprite image_1;

    public Player_1_Vector make_Vector1_length_0;
    public Player_2_Vector make_Vector2_length_0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(tempFunction());
    }

    // Update is called once per frame
    void Update()
    {
        make_Vector1_length_0.vector_x = 0;
        make_Vector1_length_0.vector_y = 0;
        make_Vector2_length_0.vector_x = 0;
        make_Vector2_length_0.vector_y = 0;
    }

    IEnumerator tempFunction()
    {
        countdown_Image.color = new Color(255, 255, 255, 255);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(1);

        countdown_Image.sprite = image_2;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(1);

        countdown_Image.sprite = image_1;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(1);

        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        countdown_Image.color = new Color(255, 255, 255, 255);
        Destroy(gameObject);
    }
}
