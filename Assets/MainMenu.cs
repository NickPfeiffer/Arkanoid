using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
