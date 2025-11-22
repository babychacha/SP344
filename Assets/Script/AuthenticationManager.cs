using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
 
public class AuthenticationManager : MonoBehaviour
{
    // ... (Variables remain the same) ...
    public TMP_InputField signUpUsernameInput;
    public TMP_InputField signUpPasswordInput;
    public GameObject signUpErrorMessage;
 
    public string nextSceneName = "Idle";
 
    private const string UsernameKey = "PlayerUsername";
    private const string PasswordKey = "PlayerPassword";
 
    void Start()
    {
        if (signUpErrorMessage != null)
        {
            signUpErrorMessage.SetActive(false);
        }
    }
 
    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม "Sign Up"
    public void HandleSignUp()
    {
        string username = signUpUsernameInput.text;
        string password = signUpPasswordInput.text;
 
        // 1. ตรวจสอบว่ากรอกข้อมูลครบถ้วนหรือไม่
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            // 🇺🇸 เปลี่ยนเป็นภาษาอังกฤษ
            ShowError("Please enter your username and password.");
            return;
        }
 
        // 2. ตรวจสอบว่ามีบัญชีอยู่แล้วหรือไม่
        if (PlayerPrefs.HasKey(UsernameKey))
        {
            // 🇺🇸 เปลี่ยนเป็นภาษาอังกฤษ
            ShowError("This account already exists.");
            return;
        }
 
        // 3. บันทึกข้อมูลด้วย PlayerPrefs
        PlayerPrefs.SetString(UsernameKey, username);
        PlayerPrefs.SetString(PasswordKey, password);
        PlayerPrefs.Save();
 
        // 🇺🇸 เปลี่ยน Debug.Log เป็นภาษาอังกฤษ
        Debug.Log("Sign Up successful: " + username);
 
        // 4. ไปยัง Scene ถัดไป
        SceneManager.LoadScene(nextSceneName);
    }
 
    // ฟังก์ชัน ShowError ที่แก้ไขแล้ว
    void ShowError(string message)
    {
        // Debug.LogError สามารถคงคำว่า "Sign Up Error" ไว้ได้
        Debug.LogError("Sign Up Error: " + message);
       
        if (signUpErrorMessage != null)
        {
            // 1. ดึง Component TextMeshProUGUI มาเพื่อแก้ไขข้อความ
            var tmpText = signUpErrorMessage.GetComponent<TextMeshProUGUI>();
           
            if (tmpText != null)
            {
                // 2. กำหนดข้อความ Error ที่รับเข้ามาในพารามิเตอร์ 'message'
                tmpText.text = "Error: " + message;
            }
           
            // 3. เปิดใช้งาน (แสดง) UI ของข้อความผิดพลาด
            signUpErrorMessage.SetActive(true);
        }
    }
}