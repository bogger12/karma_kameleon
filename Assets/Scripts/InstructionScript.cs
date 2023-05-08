using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    Sprite InstructionSprite;
    bool instructionsShowing = false;

    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            instructionsShowing = !instructionsShowing;
            this.GetComponent<SpriteRenderer>().enabled = instructionsShowing;
        }
    }
}