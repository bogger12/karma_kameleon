using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPiece;
    public GameObject latestGroundObject;

    public const float groundwidth = 64;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameSystem.gameIsOver) {
            if (latestGroundObject.transform.position.x < 8) {
                spawnGround();
            };
            GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
        }
    }

    public void spawnGround() {
        //Debug.Log("Spawn ground");
        Vector3 ltrans = latestGroundObject.transform.position + new Vector3(groundwidth/GameSystem.PixelsPerUnit, 0, 0);
        latestGroundObject = Instantiate(groundPiece, ltrans, latestGroundObject.transform.rotation, gameObject.transform);
    }
}
