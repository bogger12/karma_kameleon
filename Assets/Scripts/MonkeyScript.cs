using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyScript : MonoBehaviour
{
    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameSystem.gameIsOver) { 
            // Crude code to set moneky close to chamelon
            transform.position = new Vector3(initPos.x + 10 - GameSystem.speed, 0,0);
        }
    }
}
