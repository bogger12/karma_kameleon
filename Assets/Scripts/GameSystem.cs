using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSystem
{
    public const int PixelsPerUnit = 16;
    public const float maxposx = -12;


    public static float speed = 10;





    public static void moveChildren(GameObject gameobj, float distance) {
        foreach (Transform child in gameobj.transform) {
            //print("Foreach loop: " + child + distance.ToString());
            child.position += new Vector3(-distance, 0, 0);
        }
    }
}
