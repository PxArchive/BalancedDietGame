using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Plate"))
        {
            Debug.Log("YOU WON!");
            SceneManager.LoadScene("WinMenuScene", LoadSceneMode.Additive);
        }
    }
}
