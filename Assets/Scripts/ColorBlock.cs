using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour {
    //public Color32 blockColor = new Color32(54, 227, 66, 255);
    //public Color32 borderColor = new Color32(0, 0, 0, 255);
    //public Vector2 size = new Vector2(10, 10);
    //public int borderWidth = 1;
    public Color32 color;

    public Vector2 localcenterPos;

    // A stand-in for a constructor - initialises object variables
    public void Init(Color32 blockColor, Color32 borderColor, Vector2 size, int borderWidth) {
        this.color = blockColor;
        //this.borderColor = borderColor;
        //this.size = size;
        //this.borderWidth = borderWidth;
        // Set the sprite of this gameObject based on the parameters set
        GetComponent<SpriteRenderer>().sprite = CreateBlockSprite(blockColor, (int)size.x, (int)size.y, borderColor, borderWidth);
        gameObject.GetComponent<BoxCollider2D>().size = size/ GameSystem.PixelsPerUnit;
        gameObject.GetComponent<BoxCollider2D>().offset = (size / 2) / GameSystem.PixelsPerUnit; // Centering box about the center of block
        localcenterPos = (size / 2) / GameSystem.PixelsPerUnit;
    }
    public void Init(Color32 blockColor, Vector2 size) {
        //this.blockColor = blockColor;
        //this.size = size;
        // Set the sprite of this gameObject based on the parameters set
        GetComponent<SpriteRenderer>().sprite = CreateBlockSprite(blockColor, (int)size.x, (int)size.y);
        gameObject.GetComponent<BoxCollider2D>().size = size / GameSystem.PixelsPerUnit;
        gameObject.GetComponent<BoxCollider2D>().offset = (size/2) / GameSystem.PixelsPerUnit; // Centering box about the center of block
        localcenterPos = (size / 2) / GameSystem.PixelsPerUnit;
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < GameSystem.maxposx) {
            Destroy(gameObject);
        }
    }

    Sprite CreateBlockSprite(Color32 fillcolor, int width, int height) {

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);

        Color32[] maincolors = new Color32[width * height];
        for (int i = 0; i < width * height; i++) { maincolors[i] = fillcolor; }
        texture.SetPixels32(0, 0, width, height, maincolors);

        texture.Apply();
        texture.filterMode = FilterMode.Point;

        return Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0, 0), GameSystem.PixelsPerUnit);
    }

    Sprite CreateBlockSprite(Color32 fillcolor, int width, int height, Color bordercolor, int borderwidth) {

        Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);

        int innerBoxSize = (width - borderwidth) * (height - borderwidth);

        Color32[] InnerBoxColors = new Color32[innerBoxSize];
        for (int i = 0; i < innerBoxSize; i++) { InnerBoxColors[i] = fillcolor; }

        Color32[] HorizontalBorderColors = new Color32[width * borderwidth];
        for (int i = 0; i < width*borderwidth; i++) { HorizontalBorderColors[i] = bordercolor; }

        Color32[] VerticalBorderColors = new Color32[height * borderwidth];
        for (int i = 0; i < height*borderwidth; i++) { VerticalBorderColors[i] = bordercolor; }


        // Setting Inner Colors
        texture.SetPixels32(borderwidth, borderwidth, width - borderwidth, height - borderwidth, InnerBoxColors);

        // Setting Horizontal Borders
        texture.SetPixels32(0, 0, width, borderwidth, HorizontalBorderColors);
        texture.SetPixels32(0, height - borderwidth, width, borderwidth, HorizontalBorderColors);

        // Setting Vertical Borders
        texture.SetPixels32(0, 0, borderwidth, height, VerticalBorderColors);
        texture.SetPixels32(width - borderwidth, 0, borderwidth, height, VerticalBorderColors);

        texture.Apply();
        texture.filterMode = FilterMode.Point;

        return Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0, 0), GameSystem.PixelsPerUnit);
    }
}
