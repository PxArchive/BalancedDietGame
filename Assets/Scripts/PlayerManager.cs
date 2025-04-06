using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    int numItemsDropped = 0;
    public int numItemsUntilFail = 3;
    public bool alreadyFailed = false;

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
        if (alreadyFailed)
        {
            return;
        }

        alreadyFailed = true;
        SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Additive);
    }
}
