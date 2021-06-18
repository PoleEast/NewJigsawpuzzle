using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    private Text Font;
    [HideInInspector]
    public int touchTime;
    // Update is called once per frame
    void Start()
    {
        Font = this.GetComponent<Text>();
    }
    void Update()
    {
        Font.text = "分數:" + touchTime.ToString();
    }
}
