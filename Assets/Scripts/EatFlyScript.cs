using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EatFlyScript : MonoBehaviour
{

    //private Vector3[] positions;
    private GameObject flyObject;

    private Vector3 flyDistance;


    public float toungueTimeOut = 0.5f;

    private bool toungueIsOut = false;
    public float toungueTimer;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        toungueTimer = toungueTimeOut;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = toungueIsOut;

        if (toungueIsOut) {
            if (toungueTimer <= 0f) {
                toungueIsOut = false;
                toungueTimer = toungueTimeOut;
                flyObject.GetComponent<FlyScript>().doEat();
                return;
            }
            else {
                toungueTimer -= Time.deltaTime;
            }

            if ((toungueTimer / toungueTimeOut)>=0f) flyObject.transform.position = transform.position + (toungueTimer / toungueTimeOut) * flyDistance;
            Vector3[] positions = new Vector3[] { transform.position, flyObject.transform.position };
            lineRenderer.SetPositions(positions);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Mouth trigger enter");
        if (collision.gameObject.CompareTag("Fly")) {
            //Debug.Log("Collide with fly");
            drawLineFromMouth(collision.gameObject);
        }
    }

    void drawLineFromMouth(GameObject flyObject) {
        this.flyObject = flyObject;
        flyDistance = flyObject.transform.position - transform.position;
        flyObject.GetComponent<FlyScript>().isTounged = true;
        toungueIsOut = true;
    }
}
