using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanage : MonoBehaviour
{
    public int TouchTime;
    //if you win the number will = -1 
    private int Win=0;
   //compute win need how much
    private int winKey; 
    private Control[] alljudge;
    // Start is called before the first frame update
    void Start()
    {   
        winKey=GetComponentInChildren<CutPicture>().Mode;
        TouchTime=0;
        alljudge =GameObject.FindWithTag("GameController").GetComponentsInChildren<Control>();
　　　　
        Debug.Log(alljudge.ToString());
    }

    // Update is called once per frame
    private void Update()
    {
        Win=0;
        foreach(Control control in alljudge)
        {
            if(control.ans)
                Win++;
            if(Win==winKey*winKey&&winKey!=-1)
            {
                Win=-1;
                Debug.Log("Win");
            }
        }
    }
}
