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
    public AudioSource correctBlockSound;
    public AudioSource deathSound;

    public SpriteRenderer spriteRenderer;

    //public BoxCollider2D chameleonCBox;

    public Color chameleonGreen;
    public Color chameleonBlue;

    public GameObject scoretext;

    private ChameleonColor colorstate = ChameleonColor.GREEN;

    public Collider2D groundCollider;
    public Collider2D skyCollider;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = spriteGreen;
        spriteRenderer.color = chameleonGreen;
        animator = GetComponent<Animator>();

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

        checkIsFlying();
        animator.speed = GameSystem.speed / 10f;
    }

    private void checkIsFlying() {
        bool isflying = !GetComponent<Collider2D>().IsTouching(groundCollider);

        bool isOnCeiling = GetComponent<Collider2D>().IsTouching(skyCollider);
        spriteRenderer.flipY = isOnCeiling; // flip if touching ceiling
        if (isOnCeiling) isflying = false;
        //Debug.Log(string.Format("isFlying: {0}", isflying));


        animator.SetBool("IsFlying", isflying);
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
                GameSystem.changeSpeedBy(GameSystem.increaseonblockhit);
                correctBlockSound.Play();
            } else {
                GameSystem.changeSpeedBy(-GameSystem.speedincreaseonblockhit);
            }
            Debug.Log("collided with colorblock");
        }
        if (collision.gameObject.CompareTag("Monkey")) {
            deathSound.Play();
            GameSystem.gameEnd();
            Debug.Log("collided with monkey");
        }
    }

    private void changeColor() {
        Sprite sprite_result = null;
        switch (colorstate) {
            case ChameleonColor.GREEN:
                colorstate = ChameleonColor.BLUE;
                //sprite_result = spriteBlue;
                spriteRenderer.color = chameleonBlue;
                break;
            case ChameleonColor.BLUE:
                colorstate = ChameleonColor.GREEN;
                //sprite_result = spriteGreen;
                spriteRenderer.color = chameleonGreen;
                break;

        }
        spriteRenderer.sprite = sprite_result;

    }
}
