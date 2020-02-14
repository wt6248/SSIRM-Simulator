using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTitleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTitleScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
    public void appearButton()
    {
        UnityEngine.UI.Image buttonImage = GameObject.Find("GoToTitleButton").GetComponent<UnityEngine.UI.Image>();
        UnityEngine.UI.Text buttonText = GameObject.Find("GoToTitleButtonText").GetComponent<UnityEngine.UI.Text>();

        buttonImage.color = new Color(1, 1, 1, 1);
        buttonText.color = new Color(0, 0, 0, 1);
    }
}
