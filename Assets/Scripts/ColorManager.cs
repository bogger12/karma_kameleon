using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameObject colorBlock;

    public GameObject latestColorBlock;

    public UpdateScript Manager;

    public FlyManager flyManager;

    public float timer = 0;
    public int blockSpawnPeriod = 2;

    // Start is called before the first frame update
    void Start()
    {
        latestColorBlock = makeColorBlock(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameSystem.gameIsOver) { 
            //if (timer >= blockSpawnPeriod) {
            //    makeColorBlock();
            //    timer = 0;
            //}
            //else timer += Time.deltaTime;
            GameSystem.moveChildren(gameObject, GameSystem.speed * Time.deltaTime);
            if (latestColorBlock)

            if (latestColorBlock.transform.position.x < transform.position.x) {
                latestColorBlock = makeColorBlock(
                    (Vector2)latestColorBlock.transform.position + latestColorBlock.GetComponent<ColorBlock>().localcenterPos
                );
            }
        }
    }

    public GameObject makeColorBlock(Vector2 orig) {

        float PPUratio = 1f / 16f;

        float posY = Random.Range(-4, 4);

        float posX = transform.position.x + (GameSystem.speed * blockSpawnPeriod);
        //Debug.Log(string.Format("spawning block with x of {0}", posX));

        int width = Random.Range(10, 21);
        int height = 50; //Random.Range(20, 81);

        Vector2 blockLocation = new Vector2(posX, posY);
        GameObject penis = Instantiate(colorBlock, blockLocation, transform.rotation, transform);
        // Creates a color bock with these parameters

        int randColor = Random.Range(0, 2);
        Color32 blockColor = new Color32(0, 0, 0, 0);
        Color32 borderColor = new Color32(0, 0, 0, 0);
        switch (randColor) {
            case 0:
                blockColor = Manager.BlockGreen;
                borderColor = Manager.BlockGreenBorder;
                break;
            case 1:
                blockColor = Manager.BlockBlue;
                borderColor = Manager.BlockBlueBorder;
                break;
        }

        penis.GetComponent<ColorBlock>().Init(
            blockColor,
            borderColor,
            new Vector2(width, height),
            1
        );
        // Spawn flies from past block to this one
        //orig += new Vector2(orig.Get, (height / 2) * PPUratio);
        Vector2 centeredBlockLocation = blockLocation + new Vector2((width / 2) * PPUratio, (height / 2) * PPUratio);


        flyManager.SpawnFlies(orig+new Vector2(2,0), centeredBlockLocation - new Vector2(2, 0));

        return penis;
    }
}
