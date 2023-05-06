using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public SpriteRenderer spriteren;

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
            float fadeoffset = 2f; // how many seconds it takes to fade in

            float x = Time.time;
            if (x < 0) return;
            //float a = -1 / (((x -fadeoffset)/ 5) + 1) + 1.1f; 
            float a = -1 / (x - 5 - fadeoffset) -0.2f;

            if (a >= 1f) {
                dofade = false;
                a = 1f;
            }

            spriteren.color = new Color(1f, 1f, 1f, a);
            Debug.Log(a);
        }
    }
}
