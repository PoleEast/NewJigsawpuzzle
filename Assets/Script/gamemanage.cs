using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanage : MonoBehaviour
{
    public GameObject WinView;
    public int TouchTime;
    public GameObject Point;
    private int touchTime = 0;
    //if you win the number will = -1 
    private int Win = 0;
    //compute win need how much
    public GameObject KeyImage;
    private int winKey;
    private Control[] alljudge;
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindWithTag("music").GetComponent<AudioSource>();
        KeyImage.GetComponent<Image>().sprite = choeseKeyImage();
        winKey = GetComponentInChildren<CutPicture>().Mode;
        TouchTime = 0;
        alljudge = GameObject.FindWithTag("GameController").GetComponentsInChildren<Control>();
    }

    // Update is called once per frame
    private void Update()
    {
        Win = 0;
        foreach (Control control in alljudge)
        {
            if (control.ans)
                Win++;
            if (Win == winKey * winKey && winKey != -1)
            {
                Win = -1;
                WinView.SetActive(true);
            }
        }
        //music control
        if (touchTime != TouchTime)
        {
            music.Play();
            Point.GetComponent<Point>().touchTime = TouchTime;
            touchTime = TouchTime;
        }
    }
    private Sprite choeseKeyImage()
    {
        var Checkpoint = GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().Checkpoint;
        if (Checkpoint == 1)
            return Resources.Load<Sprite>("Image/chloe");
        if (Checkpoint == 2)
            return Resources.Load<Sprite>("Image/fate");
        if (Checkpoint == 3)
            return Resources.Load<Sprite>("Image/gwra");
        else
            Debug.Log("error");
        return null;
    }
}
