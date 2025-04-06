using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public int defaultNumFood = 1;
    private int numFood;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numFood = defaultNumFood;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        SceneManager.LoadScene(2);
    }
    
    public void TakeMoreFood()
    {
        Debug.Log("Took one more");
        numFood++;
    }

    public void ResetFood()
    {
        Debug.Log("Reset");
        numFood = defaultNumFood;
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
