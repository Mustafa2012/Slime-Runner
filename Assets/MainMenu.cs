using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
