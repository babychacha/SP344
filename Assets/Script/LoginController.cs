using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginController : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text warningText;
    public string nextSceneName = "Main_Menu";

    private void Start()
    {
        if (warningText != null)
        {
            Debug.Log("Start: hide warning text");
            warningText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("WarningText NOT assigned!");
        }
    }

    public void OnLoginButtonClicked()
    {
        Debug.Log("Login button clicked");

        string email = emailInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Some field is empty");

            if (warningText != null)
            {
                warningText.text = "Please enter both Email and Password.";
                warningText.gameObject.SetActive(true);
            }

            return;
        }

        if (warningText != null)
            warningText.gameObject.SetActive(false);

        SceneManager.LoadScene(nextSceneName);
    }

    public void OnClickClose()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
