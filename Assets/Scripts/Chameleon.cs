using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Color {
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

    private Color colorstate = Color.GREEN;

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
            case Color.GREEN:
                colorstate = Color.BLUE;
                sprite_result = spriteBlue;
                break;
            case Color.BLUE:
                colorstate = Color.GREEN;
                sprite_result = spriteGreen;
                break;

        }
        spriteRenderer.sprite = sprite_result;

    }
}
