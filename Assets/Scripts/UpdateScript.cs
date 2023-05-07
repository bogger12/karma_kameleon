using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UpdateScript : MonoBehaviour
{
    public TMP_Text scoretext;

    void Start()
    {
        GameSystem.scoreTextMesh = scoretext; 
    }

    // Update is called once per frame
    void Update()
    {
        //float speedincreaseonblockhit = 2;
        float speeddecreasepersecond = 0.5f;

        GameSystem.changeSpeedBy(-speeddecreasepersecond * Time.deltaTime);
        //Debug.Log(GameSystem.speed);

        if (Input.GetKeyDown(KeyCode.R)) { // Reload to start
           SceneManager.LoadScene("GameScene");
        }
    }
}
