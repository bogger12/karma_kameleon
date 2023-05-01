using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum ChameleonColor {
    GREEN,
    BLUE
}

public class Chameleon : MonoBehaviour
{
    public Rigidbody2D ChameleonRigidBody;
    public float floatstrength = 10;

    public SpriteRenderer spriteRenderer;

    //public BoxCollider2D chameleonCBox;

    public Sprite spriteGreen;
    public Sprite spriteBlue;

    public GameObject scoretext;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision occur");
        if (collision.gameObject.CompareTag("ColorBlock")) { 
            Color32 colorofcollision = collision.gameObject.GetComponent<ColorBlock>().color;

            bool addpoint = false;
            switch (colorstate) {
                case ChameleonColor.GREEN:
                    if (colorofcollision.Equals(BlockColors.green)) {
                        addpoint = true;
                    }
                    break;
                case ChameleonColor.BLUE:
                    if (colorofcollision.Equals(BlockColors.blue)) {
                        addpoint = true;
                    }
                    break;
            }
            if (addpoint) {
                GameSystem.addToScore(scoretext.GetComponent<TMP_Text>(), 1);
                float speedincreaseonblockhit = 2;
                GameSystem.changeSpeedBy(speedincreaseonblockhit);
            } else {
                float speedincreaseonblockhit = 2;
                GameSystem.changeSpeedBy(-speedincreaseonblockhit);
            }
            Debug.Log("collided with colorblock");
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
