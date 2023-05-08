using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public float offsetMaxValue = 8f/16f;

    public float moveRadius = 8f/16f;

    public bool isTounged = false;

    private Vector2 initPos;

    private float randOffsetX, randOffsetY, randXperiod, randYperiod, randXspeed, randYspeed;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        randOffsetX = Random.Range(-offsetMaxValue, offsetMaxValue);
        randOffsetY = Random.Range(-offsetMaxValue, offsetMaxValue);

        randXperiod = Random.Range(0, Mathf.PI);
        randYperiod = Random.Range(0, Mathf.PI);

        randXspeed = Random.Range(3, 10);
        randYspeed = Random.Range(3, 10);

        //Debug.Log(string.Format("randXperiod: {0}, randYperiod: {1}", randXperiod, randYperiod));

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GameSystem.maxposx) {
            Destroy(transform.parent.gameObject);
        }
        if (!isTounged) addRandomOffset();
    }

    void addRandomOffset() {
        float addX = Mathf.Sin(randXspeed * Time.time) * moveRadius + randOffsetX;
        float addY = Mathf.Sin(randYspeed * Time.time) * moveRadius + randOffsetY;

        //transform.position = initPos + new Vector2(addX, addY);
        transform.localPosition = new Vector2(addX, addY);
    }

    public void doEat() {
        GameSystem.addToScore(1);
        Destroy(transform.parent.gameObject);
    }

}
