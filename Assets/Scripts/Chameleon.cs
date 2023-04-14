using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ChameleonColor {
    GREEN,
    BLUE
}

public class Chameleon : MonoBehaviour
{
    public Rigidbody2D ChameleonRigidBody;
    public float floatstrength = 10;

    public SpriteRenderer spriteRenderer;

    public Sprite spriteGreen;
    public Sprite spriteBlue;

    private ChameleonColor colorstate = ChameleonColor.GREEN;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = spriteGreen;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            ChameleonRigidBody.velocity += Vector2.up * floatstrength * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.E)) {
            changeColor();
        }
    }

    private void changeColor() {
        Sprite sprite_result = null;
        switch (colorstate) {
            case ChameleonColor.GREEN:
                colorstate = ChameleonColor.BLUE;
                sprite_result = spriteBlue;
                break;
            case ChameleonColor.BLUE:
                colorstate = ChameleonColor.GREEN;
                sprite_result = spriteGreen;
                break;

        }
        spriteRenderer.sprite = sprite_result;

    }
}
