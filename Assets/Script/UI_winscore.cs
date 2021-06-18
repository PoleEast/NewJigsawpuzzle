using UnityEngine;
using UnityEngine.UI;

public class UI_winscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var touchTime=GameObject.FindWithTag("Player").GetComponent<gamemanage>().TouchTime;
        Text Font=this.GetComponent<Text>();
        Font.text="分數:"+touchTime.ToString();
    }

}
