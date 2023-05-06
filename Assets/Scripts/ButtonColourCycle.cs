using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonColourCycle : MonoBehaviour
{
    public SpriteRenderer spriteren;

    public SpriteRenderer outlineren;

    public float speed = 10;

    public float saturation = 0.7f;

    private bool visible = false;


    private Color origoutlinecolor;
    // Start is called before the first frame update
    void Start()
    {
        origoutlinecolor = outlineren.color;
        outlineren.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (visible && Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("GameScene");
        }
        float colorpoint = (Time.time * speed) % 1;
        Color color = Color.HSVToRGB(colorpoint, saturation, 1f);

        if (!visible) {
            color.a = 0f;
        } else {
            outlineren.color = origoutlinecolor;
        }


        //Color color = gradient.Evaluate(colorpoint);
        ////float h, s, v;
        //Color.RGBToHSV(color, out float h, out float s, out float v);
        //s = 0.7f;
        //color = Color.HSVToRGB(h,s,v);

        //Debug.Log(string.Format("Outline color: %s", outlineren.color));
        //Debug.Log(string.Format("Text color: %s", color));
        //Debug.Log(string.Format("Text color: %s", color));
        spriteren.color = color;


    }

    public void setVisible(bool set) { visible = set; }
}
