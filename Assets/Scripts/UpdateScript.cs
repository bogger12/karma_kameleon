using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UpdateScript : MonoBehaviour
{
    public Color32 BlockGreen = new Color32(54, 227, 66, 140);
    public Color32 BlockBlue = new Color32(54, 227, 192, 100);
    public Color32 BlockGreenBorder = new Color32(20, 100, 33, 140);
    public Color32 BlockBlueBorder = new Color32(54, 227, 66, 140);


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
           GameSystem.gameIsOver = false;
           GameSystem.speed = 10;
        }
    }
}
