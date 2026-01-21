using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public string sceneToLoad = "GameScene";  
    public float minimumTime = 3f;            

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(minimumTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}
