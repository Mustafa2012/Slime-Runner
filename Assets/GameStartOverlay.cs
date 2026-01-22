using UnityEngine;

public class GameStartOverlay : MonoBehaviour
{
    public GameObject continueOverlay;

    private bool waitingForInput = true;

    void Start()
    {
        continueOverlay.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
        
        if (waitingForInput && Input.anyKeyDown)
        {
            ContinueGame();
        }

       

    }


    void ContinueGame()
    {
        waitingForInput = false;
        continueOverlay.SetActive(false);
        Time.timeScale = 1f;
    }
}
