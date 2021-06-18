using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modecoontrol : MonoBehaviour
{
    // Start is called before the first frame update
    private static int ModeN;
    public Text Mode;
    private int Modelog;
    void Start()
    {   
        ModeN=3;
        Mode.text="Easy";
    }
    void Update() 
    {
        switch(ModeN)
        {
            case 3:
                Mode.text="Easy";
                break;
            case 4:
                Mode.text="Norma";
                break;
            case 5:
                Mode.text="Hard";
                break;
            default:
                Mode.text="Erro";
                break;              
        }
        GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().mode=ModeN;

    }
    public void UI_add()
    {
        if(ModeN<5)
        ModeN++;
    }
    public void UI_reduce()
    {
        if(ModeN>3)
        ModeN--;
    }
    public void UI_back()
    {
        SceneManager.LoadScene("menu");
    }
    public void UI_next_chloe()
    {
        SceneManager.LoadScene("GameScenes");
        GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().Checkpoint=1;
    }
    public void UI_next_fate()
    {
        SceneManager.LoadScene("GameScenes");
        GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().Checkpoint=2;
    }
    public void UI_next_gura()
    {
        SceneManager.LoadScene("GameScenes");
        GameObject.FindGameObjectWithTag("log").GetComponent<modelog>().Checkpoint=3;
    }
}
