using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



public class LightScript : MonoBehaviour
{
    public GameObject light1; // 100%
    public GameObject light2; // 96%
    public GameObject light3; // 94%
    public GameObject light4; // 99%
    public GameObject light5; // 41%
    public GameObject light6; // 100%

    public GameObject sun1; // 1% - the pixel rays
    public GameObject sun2; // 11% - the flared rays


    public float func1(float x, float lengthmod) {
        x /= lengthmod;
        return 0.3f * Mathf.Sin(x) * Mathf.Cos(Mathf.PI * x) * Mathf.Cos(4 * Mathf.PI * x) + 0.7f;
    }
    public float func2(float x, float lengthmod) {
        x /= lengthmod;
        return 0.3f * Mathf.Sin(x) * Mathf.Cos(4 * Mathf.PI * x) * Mathf.Sin(5 * x) + 0.7f;
    }
    public float func3(float x, float lengthmod) {
        x /= lengthmod;
        return 0.5f * Mathf.Sin(x) * Mathf.Cos(4 * x) + 0.5f;
    }

    public delegate float oscillatefunc(float x, float lengthmod);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateOpacity(light1, 1f, 5f, 1f, func2);
        updateOpacity(light2, 0.96f, 8f, 8f, func3);
        updateOpacity(light3, 0.94f, 5f, 3f, func2);
        updateOpacity(light4, 0.99f, 7f, 10f, func3);
        updateOpacity(light5, 0.41f, 10f, 5f, func3);
        updateOpacity(light6, 1f, 5f, 12f, func1);

        updateOpacity(sun1, 0.01f, 10f, 0.5f, func2);
        updateOpacity(sun2, 0.15f, 10f, 0.5f, func2);
    }


    void updateOpacity(GameObject light, float max_a, float lengthmod, float toffset,  oscillatefunc func) {
        //func1()
        float a;

        a = func(Time.time + toffset, lengthmod) * max_a;

        SpriteRenderer lightren = light.GetComponent<SpriteRenderer>();
        lightren.color = new Color(1f,1f,1f,a);
        //Debug.Log(a);
    }
}
