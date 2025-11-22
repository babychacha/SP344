using UnityEngine;
using UnityEngine.SceneManagement; // << อย่าลืมบรรทัดนี้

// นี่คือชื่อคลาสของ Script ที่แนบกับปุ่ม Exit ของคุณ
public class ExitScript : MonoBehaviour 
{
    // *** สร้างตัวแปร Static เพื่อส่งสถานะ (สำหรับฟังก์ชัน "พูด" ข้อความ) ***
    // (ใช้ชื่อคลาสนี้ในการอ้างอิงสถานะในฉากปลายทาง)
    public static bool JustFinishedGame = false; 
    
    // ตั้งชื่อฟังก์ชันให้เหมาะสมกับการใช้งาน
    public void GoToMarketZoneScene() 
    {
        // 1. ตั้งค่าสถานะว่าเพิ่งจบเกม (ถ้าคุณต้องการให้มีข้อความพูดตามมา)
        JustFinishedGame = true;
        
        // 2. *** สำคัญมาก: ระบุชื่อฉากใหม่ให้ "ตรงทุกตัวอักษร" ***
        // จากภาพคือ "Market Zone" (มีช่องว่าง)
        string targetSceneName = "Market Zone";

        // 3. โหลดฉากเป้าหมาย
        SceneManager.LoadScene(targetSceneName); 
    }
}