using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct BlockColors {
    //public readonly Color32 green;

    public static Color32 green {
        get { return new Color32(54, 227, 66, 140); }
    }
    public static Color32 blue {
        get { return new Color32(54, 227, 192, 100); }
    }
    public static Color32 black {
        get { return new Color32(0, 0, 0, 50); }
    }

    public static Color32 get(int index) {
        switch (index) {
            case 0:
                return green;
            case 1:
                return blue;
            default:
                return black;
        }
    }
}


public static class GameSystem
{
    public const int PixelsPerUnit = 16;
    public const float maxposx = -12;

    public static int score = 0; //  Current score of player

    public static bool gameIsOver = false;

    public static float speed = 10; // speed that chameleon runs at

    public static float speedincreaseonblockhit = 2f;

    public static GameObject gameOverLayer0;
    public static GameObject gameOverLayer1;

    public static int sceneLength = 5;


    public static void moveChildren(GameObject gameobj, float distance) {
        foreach (Transform child in gameobj.transform) {
            //print("Foreach loop: " + child + distance.ToString());
            child.position += new Vector3(-distance, 0, 0);
        }
    }

    public static void addToScore(TMP_Text textMesh, int scoretoadd) {
        score += scoretoadd;
        textMesh.text = string.Format("Score: {0}", score);
    }

    public static void changeSpeedBy(float change) {
        if (!GameSystem.gameIsOver) speed += change;
    }
    public static void gameEnd() {
        speed = 0;
        gameIsOver = true;
        gameOverLayer0 = GameObject.FindGameObjectWithTag("GameOverL0");
        gameOverLayer1 = GameObject.FindGameObjectWithTag("GameOverL1");
        gameOverLayer0.GetComponent<SpriteRenderer>().enabled = true;
        gameOverLayer1.GetComponent<SpriteRenderer>().enabled = true;
    }
}
