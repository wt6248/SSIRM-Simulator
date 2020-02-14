using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCircleColor : MonoBehaviour
{
    public VectorManager vector_data_reference;
    UnityEngine.UI.Image target_image;
    // Start is called before the first frame update
    void Start()
    {
        target_image = GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        target_image.color = vector_data_reference.what_Circle_Color();
    }
}
