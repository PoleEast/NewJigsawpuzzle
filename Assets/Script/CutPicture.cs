using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPicture : MonoBehaviour
{
    private Texture2D SoureImage;
    //mod = cut quantity
    [HideInInspector]
    public int Mode;
    public GameObject Control;
    //new sprite name number
    private int number;
    private bool[,] check;
    private int rndRC;
    public void Awake()
    {
        SoureImage = choeseIMG();
        Mode = GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().mode;
        int Rad_i = Random.Range(0, 3);
        int Rad_j = Random.Range(0, 3);
        check = new bool[Mode, Mode];
        number = Mode * Mode;
        //i Col J Row
        for (int i = 0; i < Mode; i++)
            for (int j = Mode - 1; j >= 0; j--)
            {
                number--;
                string name;
                if (i == Rad_i && j == Rad_i)
                    name = "holo";
                else
                    name = "P" + number.ToString();
                //compute new image edge width and interval
                float imageEdgeRevise = (float)(SoureImage.width / 100f) / Mode;
                creatOB(i, j, name, imageEdgeRevise);
            }
    }
    //i and j is image position
    private void creatOB(int i, int j, string name, float imageEdgeRevise)
    {
        var newimage = new GameObject(name);
        newimage.transform.parent = Control.transform;
        var vector = new Vector3(i * imageEdgeRevise + imageEdgeRevise / 2f, j * imageEdgeRevise + imageEdgeRevise / 2f, 0);
        newimage.transform.localPosition = vector;
        var script = newimage.AddComponent<Control>();
        script.Row = j;
        script.Col = i;
        rndRC = Rng();
        script.KeyR = rndRC - (rndRC / 10) * 10;
        script.KeyC = rndRC / 10;
        var boxCollider2D = newimage.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(imageEdgeRevise, imageEdgeRevise);
        var spriteRenderer = newimage.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = cutpicture(SoureImage, Mode, rndRC - (rndRC / 10) * 10, rndRC / 10);
        if (name == "holo")
        {
            newimage.tag = "holo";
            spriteRenderer.color = Color.gray;
        }
        else
            newimage.tag = "IMG";
    }
    private Sprite cutpicture(Texture2D soureimage, int mod, int i, int j)
    {
        var textureW = soureimage.height * i / mod;
        var textureH = soureimage.width * j / mod;
        var rect = new Rect(textureH, textureW, soureimage.width / mod, soureimage.height / mod);
        var sprite = Sprite.Create(soureimage, rect, Vector2.one * 0.5f);
        return sprite;
    }
    //RNG ImageGameObject Position
    private int Rng()
    {
        while (true)
        {
            int c = Random.Range(0, Mode);
            int r = Random.Range(0, Mode);
            if (check[r, c] != true)
            {
                check[r, c] = true;
                return r * 10 + c;
            }
        }
    }
    private Texture2D choeseIMG()
    {
        var Checkpoint = GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().Checkpoint;
        if (Checkpoint == 1)
            return Resources.Load<Texture2D>("Image/chloe");
        if (Checkpoint == 2)
            return Resources.Load<Texture2D>("Image/fate");
        if (Checkpoint == 3)
            return Resources.Load<Texture2D>("Image/gwra");
        else
            Debug.Log("error");
        return null;
    }
}
