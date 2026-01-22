using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public float minimumTime = 3f;
    public string menuSceneName = "MenuScene"; 

    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(minimumTime);
        SceneManager.LoadScene(menuSceneName);
    }
}
