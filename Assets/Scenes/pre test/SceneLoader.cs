using UnityEngine;
using UnityEngine.SceneManagement; // **ต้องมีบรรทัดนี้เพื่อเข้าถึง SceneManager**

public class SceneLoader : MonoBehaviour
{
    // ฟังก์ชันสาธารณะ (public) ที่รับชื่อ Scene เป็นพารามิเตอร์
    public void LoadNewScene(string sceneName)
    {
        // 1. ตรวจสอบความถูกต้องของชื่อ Scene ก่อนโหลด
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("ERROR: Scene name cannot be empty. Please check your settings.");
            return; // หยุดการทำงานถ้าชื่อว่างเปล่า
        }
        
        // 2. ใช้คำสั่งหลักในการเปลี่ยน Scene
        SceneManager.LoadScene(sceneName);
        
        // 3. (ทางเลือก) แสดงข้อความยืนยันใน Console
        Debug.Log("Scene loading initiated for: " + sceneName);
    }
}
