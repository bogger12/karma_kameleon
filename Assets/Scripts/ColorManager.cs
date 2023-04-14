using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BlockColors {
    //public readonly Color32 green;

    public static Color32 green {
        get { return new Color32(54, 227, 66, 255); }
    }
    public static Color32 blue {
        get { return new Color32(54, 227, 192, 255); }
    }
    public static Color32 black {
        get { return new Color32(0, 0, 0, 255); }
    }

    public static Color32 get(int index) {
        switch(index) {
            case 0:
                return green;
            case 1:
                return blue;
            default:
                return black;
        }
    }
}

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

        if (timer >= blockSpawnPeriod) {
            makeColorBlock();
            timer = 0;
        }
        else timer += Time.deltaTime;
        GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
    }

    public void makeColorBlock() {

        int posY = Random.Range(-4, 4);

        int width = Random.Range(10, 21);
        int height = 50; //Random.Range(20, 81);

        GameObject penis = Instantiate(colorBlock, new Vector3(transform.position.x, posY, 0), transform.rotation, transform);
        penis.GetComponent<ColorBlock>().Init(
            BlockColors.get(Random.Range(0, 2)),
            BlockColors.black,
            new Vector2(width, height),
            1
        );
    }
}
