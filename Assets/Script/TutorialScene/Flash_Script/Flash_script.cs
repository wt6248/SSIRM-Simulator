using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Flash_script : MonoBehaviour
{
    public Image flash_w;
    public Image flash_a;
    public Image flash_s;
    public Image flash_d;
    public Image flash_up;
    public Image flash_down;
    public Image flash_left;
    public Image flash_right;

    float flash_power;
    // Start is called before the first frame update
    void Start()
    {
        flash_power = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Btn_w_Flash();
        Btn_s_Flash();
        Btn_a_Flash();
        Btn_d_Flash();
        Btn_up_Flash();
        Btn_down_Flash();
        Btn_left_Flash();
        Btn_right_Flash();
    }

    void Btn_w_Flash()
    {
        if (Input.GetKey(KeyCode.W))
            flash_w.color = new Color(1, 1, 1, flash_power);
        else
            flash_w.color = new Color(1, 1, 1, 0);
    }
    void Btn_s_Flash()
    {
        if (Input.GetKey(KeyCode.S))
            flash_s.color = new Color(1, 1, 1, flash_power);
        else
            flash_s.color = new Color(1, 1, 1, 0);
    }
    void Btn_a_Flash()
    {
        if (Input.GetKey(KeyCode.A))
            flash_a.color = new Color(1, 1, 1, flash_power);
        else
            flash_a.color = new Color(1, 1, 1, 0);
    }
    void Btn_d_Flash()
    {
        if (Input.GetKey(KeyCode.D))
            flash_d.color = new Color(1, 1, 1, flash_power);
        else
            flash_d.color = new Color(1, 1, 1, 0);
    }

    void Btn_up_Flash()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            flash_up.color = new Color(1, 1, 1, flash_power);
        else
            flash_up.color = new Color(1, 1, 1, 0);
    }

    void Btn_down_Flash()
    {
        if (Input.GetKey(KeyCode.DownArrow))
            flash_down.color = new Color(1, 1, 1, flash_power);
        else
            flash_down.color = new Color(1, 1, 1, 0);
    }
    void Btn_left_Flash()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            flash_left.color = new Color(1, 1, 1, flash_power);
        else
            flash_left.color = new Color(1, 1, 1, 0);
    }
    void Btn_right_Flash()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            flash_right.color = new Color(1, 1, 1, flash_power);
        else
            flash_right.color = new Color(1, 1, 1, 0);
    }
    

}
