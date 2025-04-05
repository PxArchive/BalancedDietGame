using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        SceneManager.LoadScene(1);
    }
    
    public void TakeMoreFood()
    {
        Debug.Log("Took one more");
        //TODO adding food to tray
    }

    public void ResetFood()
    {
        Debug.Log("Reset");
        //TODO reset
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
