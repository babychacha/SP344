using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    // ไม่ต้องเป็น Singleton ด้วยตัวเอง แต่ใช้ ScoreManager ช่วยทำให้รอดข้าม Scene
    
    public static string currentTestStartScene = "pre 1"; // Default start scene

    // ลบ Awake() ทิ้ง!
    
    void OnEnable()
    {
        // ... (Logic เดิม) ...
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // ... (Logic เดิม) ...
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ... (Logic เดิม) ...
        if (scene.name == "pre 1" || scene.name == "post 1")
        {
            currentTestStartScene = scene.name;
            Debug.Log("บันทึก Scene เริ่มต้น: " + currentTestStartScene);
        }
    }
    
    // ----------------------------------------------------------------
    // ฟังก์ชันสำหรับปุ่ม Replay/Exit (ต้องเรียก ScoreManager.Instance เพื่อทำลาย)
    // ----------------------------------------------------------------

    // ฟังก์ชัน Replay เดิม (Dynamic)
    public void ReplayGame()
    {
        // เราต้องหา ScoreManager Instance ที่รอดมาเพื่อสั่งทำลายมัน
        if (ScoreManager.Instance != null)
        {
            Destroy(ScoreManager.Instance.gameObject); 
        }
        SceneManager.LoadScene(currentTestStartScene);
    }
    
    // Replay Post-test โดยตรง (สำหรับปุ่ม Replay ใน score1)
    public void ReplayPostTest()
    {
        if (ScoreManager.Instance != null)
        {
            Destroy(ScoreManager.Instance.gameObject);
        }
        SceneManager.LoadScene("post 1"); // โหลด post 1 โดยตรง
    }
    
    // ฟังก์ชัน Exit/กลับไป Scene post 1 (สำหรับปุ่ม Exit ใน score1)
    public void GoToPostTestStart()
    {
        if (ScoreManager.Instance != null)
        {
            Destroy(ScoreManager.Instance.gameObject);
        }
        SceneManager.LoadScene("post 1");
    }
}
