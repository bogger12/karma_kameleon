using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject colorBlock;

    public float timer = 0;
    public int blockSpawnPeriod = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameSystem.gameIsOver) { 
            if (timer >= blockSpawnPeriod) {
                makeColorBlock();
                timer = 0;
            }
            else timer += Time.deltaTime;
            GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
        }
    }

    public void makeColorBlock() {

        int posY = Random.Range(-4, 4);

        int width = Random.Range(10, 21);
        int height = 50; //Random.Range(20, 81);

        GameObject penis = Instantiate(colorBlock, new Vector3(transform.position.x, posY, 0), transform.rotation, transform);
        // Creates a color bock with these parameters
        penis.GetComponent<ColorBlock>().Init(
            BlockColors.get(Random.Range(0, 2)),
            BlockColors.black,
            new Vector2(width, height),
            1
        );
    }
}
