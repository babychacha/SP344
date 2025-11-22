using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPreTest : MonoBehaviour
{
    public string sceneName = "pre 1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
