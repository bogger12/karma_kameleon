using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPiece;
    public GameObject latestGroundObject;

    public float movespeed = 10;

    public const float ppu = 16;
    public const float groundwidth = 64;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (latestGroundObject.transform.position.x < 8) {
            spawnGround();
        };
        moveGround(movespeed * Time.deltaTime);
    }

    public void spawnGround() {
        //Debug.Log("Spawn ground");
        Vector3 ltrans = latestGroundObject.transform.position + new Vector3(groundwidth/16, 0, 0);
        latestGroundObject = Instantiate(groundPiece, ltrans, latestGroundObject.transform.rotation, gameObject.transform);
    }

    public void moveGround(float distance) {
        foreach (Transform child in transform) {
            //print("Foreach loop: " + child + distance.ToString());
            child.position += new Vector3(-distance, 0, 0);
        }
    }
}
