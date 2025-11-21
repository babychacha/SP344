using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SignupController : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text warningText;
    public string nextSceneName = "Main_Menu";

    private void Start()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);   // ซ่อนตอนเริ่ม
    }

    public void OnClickSignup()
    {
        Debug.Log("SIGNUP CLICKED");

        string email = emailInput.text.Trim();
        string password = passwordInput.text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Some field is empty");

            if (warningText != null)
            {
                warningText.text = "Please enter both Email and Password.";
                warningText.gameObject.SetActive(true);   // เปิดตัวแดง
            }
            return;
        }

        if (warningText != null)
            warningText.gameObject.SetActive(false);

        SceneManager.LoadScene(nextSceneName);
    }
}
