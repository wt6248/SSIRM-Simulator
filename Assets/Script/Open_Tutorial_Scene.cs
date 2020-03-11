using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Tutorial_Scene : MonoBehaviour
{
    public void LoadTurtorialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialScene");
    }
}
