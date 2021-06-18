using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_game : MonoBehaviour
{
     private bool soundStatus=true;
    // Start is called before the first frame update
    public void UI_soundControl()
    {
        var music=GameObject.FindWithTag("music");
        var image=GameObject.Find("SoundControl").GetComponent<Image>();

        if(soundStatus==true)
        {
            music.GetComponent<AudioSource>().mute=true;
            image.sprite= Resources.Load<Sprite>("Sprites/soundoff");
            soundStatus=false;
        }
        else if(soundStatus==false)
        {
            music.GetComponent<AudioSource>().mute=false;
            image.sprite = Resources.Load<Sprite>("Sprites/soundon");
            soundStatus=true;
        }        
    } 
    public void UI_back()
    {
        SceneManager.LoadScene("menu");
        Debug.Log("BACK");
    }
}
