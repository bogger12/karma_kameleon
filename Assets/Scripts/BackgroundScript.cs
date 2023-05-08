using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject bg1_prefab;
    public GameObject bg2_prefab;
    public GameObject bg3_prefab;
    public GameObject bg4_prefab;

    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    public GameObject bg4;

    //public GameObject latestGroundObject;

    public const float bgwidth = 320;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (!GameSystem.gameIsOver) {
            //if (bg1.transform.position.x <= -20) { spawnBG(ref bg1, bg1_prefab); };
            //if (bg2.transform.position.x <= -20) { spawnBG(ref bg2, bg2_prefab); };
            //if (bg3.transform.position.x <= -20) { spawnBG(ref bg3, bg3_prefab); };
            //if (bg4.transform.position.x <= -20) { spawnBG(ref bg4, bg4_prefab); };

            //GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
            //Move(bg1, Time.deltaTime * GameSystem.speed * 0f);
            //Move(bg2, Time.deltaTime * GameSystem.speed * 0.2f);
            //Move(bg3, Time.deltaTime * GameSystem.speed * 0.5f);
            //Move(bg4, Time.deltaTime * GameSystem.speed * 1f);

            foreach (Transform child in gameObject.transform) {
                //print("Foreach loop: " + child + distance.ToString());
                GameObject gobject = child.gameObject;
                //Debug.Log(gobject.name);
                switch (child.gameObject.tag) {
                    case "bg1":
                        if (bg1.transform.position.x <= 0) { spawnBG(ref bg1, bg1_prefab); };
                        Move(gobject, Time.deltaTime * GameSystem.speed * 0f);
                        break;
                    case "bg2":
                        if (bg2.transform.position.x <= 0) { spawnBG(ref bg2, bg2_prefab); };
                        Move(gobject, Time.deltaTime * GameSystem.speed * 0.2f);
                        break;
                    case "bg3":
                        if (bg3.transform.position.x <= 0) { spawnBG(ref bg3, bg3_prefab); };
                        Move(gobject, Time.deltaTime * GameSystem.speed * 0.5f);
                        break;
                    case "bg4":
                        if (bg4.transform.position.x <= 0) { spawnBG(ref bg4, bg4_prefab); };
                        Move(gobject, Time.deltaTime * GameSystem.speed * 1f);
                        break;
                    default:
                        Debug.Log("WRONG NAME");
                        break;

                }
            }
        }
    }

    public void spawnBG(ref GameObject latest, GameObject instantiate) {
        //Debug.Log("Spawn ground");
        Vector3 ltrans = latest.transform.position + new Vector3(bgwidth / GameSystem.PixelsPerUnit, 0, 0);
        latest = Instantiate(instantiate, ltrans, latest.transform.rotation, gameObject.transform);
    }

    public void Move(GameObject gObject, float distance) {
        if (gObject.transform.position.x < -20) Destroy(gObject);
        gObject.transform.position += new Vector3(-distance, 0, 0);
    }

}
