using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthSceneController : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("login");    // ชื่อ Scene login
    }

    public void GoToSignup()
    {
        SceneManager.LoadScene("sign up");  // ชื่อ Scene sign up
    }
}
