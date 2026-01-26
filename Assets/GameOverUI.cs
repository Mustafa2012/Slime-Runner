using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene("GameScene"); 
        Time.timeScale = 1f; 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
}
