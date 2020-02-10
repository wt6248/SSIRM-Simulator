using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCircleColor : MonoBehaviour
{
    public VectorManager vector_data_reference;
    SpriteRenderer target_sprite;
    // Start is called before the first frame update
    void Start()
    {
        target_sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        target_sprite.color = vector_data_reference.what_Circle_Color();
    }
}
