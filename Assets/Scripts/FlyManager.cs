using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
    public GameObject Fly;

    public void SpawnFlies(Vector2 flyStartLocation, Vector2 flyEndLocation) {
        // Gets location of fly based on x coordinate - x is a float from 0 to 1
        Vector2 flyLocation(float x) {
            float y = -0.5f * Mathf.Cos(Mathf.PI * x) + 0.5f;
            Vector2 difference = flyEndLocation - flyStartLocation;
            return flyStartLocation + difference * (new Vector2(x, y));
        }
        float numflies = Mathf.Round( GameSystem.speed/2) - 1;

        for (int i = 0; i <= numflies; i++) {
            Instantiate(Fly, flyLocation(i/numflies), transform.rotation, transform);
        }
        //Debug.Log(string.Format("spawned {0} flies", numflies));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameSystem.gameIsOver) {
            GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
        }
    }
}
