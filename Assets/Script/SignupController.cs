using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SignupController : MonoBehaviour
{
    // Keys ที่ใช้บันทึกข้อมูล
    private const string UsernameKey = "PlayerUsername";
    private const string PasswordKey = "PlayerPassword";

    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text warningText;
    public string nextSceneName = "Main_Menu";

    private void Start()
    {
        
        // ซ่อนข้อความ Error ตอนเริ่มต้น
        if (warningText != null)
            warningText.gameObject.SetActive(false); 
    }

    // ฟังก์ชันนี้คือฟังก์ชันที่ต้องเชื่อมต่อกับปุ่ม Sign up (OnClickSignup)
    public void OnClickSignup() 
    {
        Debug.Log("SIGNUP CLICKED");

        string email = emailInput.text.Trim();
        string password = passwordInput.text;

        // 1. Check for empty fields
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowWarning("Error: Please enter both Email and Password.");
            return;
        }

        // 2. Check for existing account 
        if (PlayerPrefs.HasKey(UsernameKey))
        {
            ShowWarning("Error: This account already exists. Please log in.");
            return;
        }

        // 3. Save data
        PlayerPrefs.SetString(UsernameKey, email);
        PlayerPrefs.SetString(PasswordKey, password);
        PlayerPrefs.Save(); 

        Debug.Log("Sign Up successful. Account: " + email);
        
        // 4. Load Scene
        SceneManager.LoadScene(nextSceneName);
    }

    // Helper function to show warning
    void ShowWarning(string message)
    {
        Debug.LogError("SIGNUP Error: " + message);
        if (warningText != null)
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true); 
        }
    }
    
    public void OnClickClose()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}