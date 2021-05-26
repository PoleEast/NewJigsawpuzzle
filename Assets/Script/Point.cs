using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var touchTime=GameObject.FindWithTag("Player").GetComponent<gamemanage>().TouchTime;
        var font=this.GetComponent<Text>();
        font.text="分數:"+touchTime.ToString();
    }
}
