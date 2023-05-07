using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //float speedincreaseonblockhit = 2;
        float speeddecreasepersecond = 0.5f;

        GameSystem.changeSpeedBy(-speeddecreasepersecond * Time.deltaTime);
        //Debug.Log(GameSystem.speed);
    }
}
