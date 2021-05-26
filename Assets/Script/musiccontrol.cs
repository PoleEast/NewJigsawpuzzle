using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musiccontrol : MonoBehaviour
{
    private GameObject music;
    private Image image;
    private bool soundStatus=true;
    // Start is called before the first frame update
    public void OnClick()
    {
        music=GameObject.FindWithTag("music");
        image=this.GetComponent<Image>();

        if(soundStatus==true)
        {
            music.GetComponent<AudioSource>().mute=true;
            image.sprite = Resources.Load<Sprite>("Sprites/soundoff");
            soundStatus=false;
        }
        else if(soundStatus==false)
        {
            music.GetComponent<AudioSource>().mute=false;
            image.sprite = Resources.Load<Sprite>("Sprites/soundon");
            soundStatus=true;
        }        

    } 
}
