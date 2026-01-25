using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
