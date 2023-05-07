using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public GameObject chameleon;
    // Start is called before the first frame update
    void Start()
    {
        chameleon = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GameSystem.maxposx) {
            Destroy(gameObject);
        }

        // Make colour more saturated closer it is to chameleon
        SpriteRenderer spriteren = GetComponent<SpriteRenderer>();
        Color.RGBToHSV(spriteren.color, out float h, out float s, out float v);

        v = 1f-Mathf.Abs((chameleon.transform.position - transform.position).magnitude/15);
        spriteren.color = Color.HSVToRGB(h, s, v);
    }
}
