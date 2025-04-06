using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    int numItemsDropped = 0;
    int numItemsUntilFail;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemDropped()
    {
        ++numItemsDropped;
        if (numItemsDropped >= numItemsUntilFail)
        {
            OnFail();
        }
    }

    void OnFail()
    {
        SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Additive);
    }
}
