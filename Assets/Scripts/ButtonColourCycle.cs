using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColourCycle : MonoBehaviour
{
    public SpriteRenderer spriteren;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float penis1 = (Time.time * speed) % 1;
        Color penis2 = Color.HSVToRGB(penis1, 0.7f, 1f);
        spriteren.color = penis2;
    }
}
