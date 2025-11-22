using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SignupController : MonoBehaviour
{
    // เปลี่ยน Keys ให้รองรับหลายบัญชี: ใช้ Email เป็นส่วนหนึ่งของคีย์
    private const string PasswordPrefix = "Password_"; 

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

    // Helper function ที่คุณต้องการใช้งาน (ต้องประกาศเป็น private/public ในคลาส)
    void ShowWarning(string message)
    {
        Debug.LogError("SIGNUP Error: " + message);
        if (warningText != null)
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true); 
        }
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

        // สร้างคีย์เฉพาะสำหรับรหัสผ่านของอีเมลนี้
        string passwordKeyForUser = PasswordPrefix + email;

        // 2. Check for existing account (ถ้าคีย์เฉพาะเจาะจงของ Email นี้มีอยู่แล้ว)
        if (PlayerPrefs.HasKey(passwordKeyForUser)) 
        {
            ShowWarning("Error: This Email is already registered. Please log in.");
            return;
        }

        // 3. Save data
        PlayerPrefs.SetString(passwordKeyForUser, password);
        PlayerPrefs.Save(); 

        Debug.Log("Sign Up successful. Account: " + email);
        
        // 4. Load Scene
        SceneManager.LoadScene(nextSceneName);
    }

    public void OnClickClose()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}