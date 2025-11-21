using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("Center Zone 1");
    }

    public void OnClickLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void OnClickExit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
