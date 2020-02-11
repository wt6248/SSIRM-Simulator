using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareScene_Button_script : MonoBehaviour
{
    public AudioSource stop_This_BGM;
    public GameObject destroy_This_Button;
    AudioSource zzing_sound;
    public Sprite half_judge;
    public Sprite wake_judge;
    public Sprite player_wake;
    public SpriteRenderer judge;
    public SpriteRenderer player;
    public CrowdScript stop_Crowd_movement;
    // Start is called before the first frame update
    void Start()
    {
        zzing_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void prepare_Game()
    {
        StartCoroutine(Something());
    }

    IEnumerator Something()
    {
        //버튼 안보이게 함.
        Destroy(destroy_This_Button);
        stop_This_BGM.Stop();
        zzing_sound.Play();
        yield return new WaitForSeconds(1);

        //심판이 일어남.
        judge.sprite = half_judge;
        yield return new WaitForSeconds(2);
        judge.sprite = wake_judge;
        yield return new WaitForSeconds(2);

        // 징소리가 울림.

        //움직이는 거 멈춤.
        stop_Crowd_movement.stop_crowd_move();
        yield return new WaitForSeconds(5);

        //선수 일어남.
        player.sprite = player_wake;
        yield return new WaitForSeconds(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
