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
            Vector3 modVector = new Vector3(initPos.x + 10 - GameSystem.speed, 0, 0);
            //if (transform.position.x >= -10 || modVector.x >= -10) transform.position = modVector;
            //else transform.position = new Vector3(-10, transform.position.y, 0);
            transform.position = modVector;
            if (transform.position.x < -10) transform.position = new Vector2(-10, transform.position.y);
        }
    }
}
