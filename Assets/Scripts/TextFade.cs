using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public SpriteRenderer spriteren;

    public ButtonColourCycle cyclescript;

    public GameObject instructbutton;

    private bool dofade = true;

    public float initTime;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
        spriteren.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (dofade) {
            float fadeoffset = -2f; // seconds before it starts to fade in

            float x = Time.time-initTime;
            //Debug.Log(string.Format("time: {0}", x));

            if (x < 0) return;
            float a = -1 / ((x - 5)*2 - fadeoffset) -0.2f;
            //Debug.Log(string.Format("opacity: {0}", a));

            if (a >= 1f) {
                dofade = false;
                a = 1f;
                cyclescript.setVisible(true); // Here is when the button becomes visible
                instructbutton.SetActive(true);
            }

            spriteren.color = new Color(1f, 1f, 1f, a);
        }
    }
}
