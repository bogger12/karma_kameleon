using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : MonoBehaviour
{
    public Rigidbody2D ChameleonRigidBody;
    public float floatstrength = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            ChameleonRigidBody.velocity += Vector2.up * floatstrength * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("collision enter");
        ChameleonRigidBody.velocity *= new Vector2(0, 0);
    }
}
