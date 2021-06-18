using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_menu : MonoBehaviour
{
    public GameObject Exitmenu;
    // Update is called once per frame
    public void UI_Start()
    {
        SceneManager.LoadScene("chancemode");
    }
    public void UI_CallExitMenu()
    {
        Exitmenu.SetActive(true);
    }
    public void UI_Exit()
    {
        Application.Quit();
    }
    public void UI_NoExit()
    {
        Exitmenu.SetActive(false);
    }
}
