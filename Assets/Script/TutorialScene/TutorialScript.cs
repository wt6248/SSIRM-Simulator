using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    int TutorialState;
    // Start is called before the first frame update
    void Start()
    {
        TutorialState = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //System.Type tp = typeof(TutorialScript);
            //System.Reflection.MethodInfo method = tp.GetMethod("getScript_1");
            //method.Invoke(null, new object[] { });
            Invoke("getScript_" + TutorialState.ToString(), 0f);
        }


    }

    void getScript_0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}
