using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public SpriteRenderer spriteren;

    public ButtonColourCycle cyclescript;

    private bool dofade = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteren.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dofade) {
            float fadeoffset = -2f; // seconds before it starts to fade in

            float x = Time.time;
            if (x < 0) return;
            float a = -1 / ((x - 5)*2 - fadeoffset) -0.2f;

            if (a >= 1f) {
                dofade = false;
                a = 1f;
                cyclescript.setVisible(true); // Here is when the button becomes visible
            }

            spriteren.color = new Color(1f, 1f, 1f, a);
        }
    }
}
