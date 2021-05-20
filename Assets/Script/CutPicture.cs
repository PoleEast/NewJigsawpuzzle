using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CutPicture : MonoBehaviour
{
    public Texture2D SoureImage;
    //mod = cut quantity
    public int Mode;
    public GameObject Control;
    //new sprite name number
    private int number;
    private bool[,] check;
    private int rndRC;
    public void Awake()
    {
        check=new bool[Mode,Mode];
        number = Mode * Mode;
        //i Col J Row
        for (int i = 0; i < Mode; i++)
            for (int j = Mode - 1; j >= 0; j--)
            {
                number--;
                Random rng=new Random();
                string name;
                if(i==1&&j==1)
                    name="holo";
                else
                    name="P"+number.ToString();
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
        if(name=="holo")
            newimage.tag="holo";
        else
            newimage.tag="IMG";
        var vector = new Vector3(i * imageEdgeRevise + imageEdgeRevise / 2f, j * imageEdgeRevise + imageEdgeRevise / 2f, 0);
        newimage.transform.localPosition = vector;
        var script = newimage.AddComponent<Control>();
        script.Row=j;
        script.Col=i;
        rndRC=Rng();
        script.KeyR=rndRC-(rndRC/10)*10;
        script.KeyC=rndRC/10;
        var boxCollider2D = newimage.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(imageEdgeRevise, imageEdgeRevise);
        var SpriteRenderer = newimage.AddComponent<SpriteRenderer>();
        SpriteRenderer.sprite = cutpicture(SoureImage, Mode, rndRC-(rndRC/10)*10, rndRC/10);
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
        while(true)
        {
            int c=Random.Range(0,Mode);
            int r=Random.Range(0,Mode);
            if(check[r,c]!=true)
            {
                check[r,c]=true;
                return r*10+c;
            }
        }
    }
}
