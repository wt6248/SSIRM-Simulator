using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("PrepareScene");
    }
}
