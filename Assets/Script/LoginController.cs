using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginController : MonoBehaviour
{
    // ต้องใช้ Prefix เดียวกันกับที่ใช้ใน SignupController.cs
    private const string PasswordPrefix = "Password_"; 

    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text warningText;
    public string nextSceneName = "Main_Menu";

    private void Start()
    {
        // ซ่อนข้อความ Error ตอนเริ่มต้น
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

    // Helper function เพื่อแสดงข้อความเตือน
    void ShowWarning(string message)
    {
        Debug.LogError("LOGIN Error: " + message);
        if (warningText != null)
        {
            warningText.text = message;
            warningText.gameObject.SetActive(true);
        }
    }

    public void OnLoginButtonClicked()
    {
        Debug.Log("Login button clicked");

        string email = emailInput.text.Trim();
        string password = passwordInput.text;
        
        // สร้างคีย์เฉพาะสำหรับรหัสผ่านของ Email นี้
        string passwordKeyForUser = PasswordPrefix + email;

        // 1. Check for empty fields
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ShowWarning("Please enter both Email and Password.");
            return;
        }

        // 2. Check if the Email is registered (ตรวจสอบว่ามีคีย์นี้หรือไม่)
        if (!PlayerPrefs.HasKey(passwordKeyForUser))
        {
            ShowWarning("Error: Account not found. Please sign up or check your email.");
            return;
        }

        // 3. Check if the Password is correct (ดึงรหัสผ่านที่บันทึกไว้มาเทียบ)
        string savedPassword = PlayerPrefs.GetString(passwordKeyForUser);
        
        if (savedPassword != password)
        {
            ShowWarning("Error: Invalid password. Please try again.");
            return;
        }

        // 4. Authentication Successful!
        Debug.Log("Login successful for: " + email);
        
        // ** (เสริม): บันทึกสถานะผู้ใช้ปัจจุบัน (Current User) **
        // นี่เป็นขั้นตอนเสริมที่สำคัญมาก เพื่อให้เกมรู้ว่าใครกำลังเล่นอยู่
        PlayerPrefs.SetString("CurrentUser", email); 
        PlayerPrefs.Save(); 

        // 5. Load Scene
        SceneManager.LoadScene(nextSceneName);
    }

    public void OnClickClose()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}