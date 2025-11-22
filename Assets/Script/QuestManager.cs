using UnityEngine;
using UnityEngine.SceneManagement; // ต้องเพิ่มอันนี้เพื่อใช้ตรวจสอบ Scene

public class QuestManager : MonoBehaviour
{
    // ตัวแปรสำหรับอ้างอิงถึงข้อความเควสที่เราสร้างไว้
    public GameObject healthZoneQuestUI;

    // ชื่อ Scene ของศูนย์อนามัย (ตรวจสอบจากใน Project/Scenes)
    // จากภาพที่คุณส่งมา ชื่อ Scene น่าจะเป็น 'Health Zone' หรือ 'Health_Zone' 
    // ให้ตรวจสอบชื่อที่ถูกต้องและใส่ในบรรทัดด้านล่างนี้
    private const string TargetSceneName = "Health Zone"; // <<< แก้ไขตรงนี้ให้ตรงกับชื่อ Scene ของคุณ!

    void Start()
    {
        // สั่งให้ตรวจสอบสถานะทันทีที่ Scene โหลด
        CheckQuestStatus();
    }

    // ฟังก์ชันนี้จะถูกเรียกเมื่อมีการเปลี่ยน Scene
    private void OnEnable()
    {
        // สมัครรับ Event เมื่อมีการโหลด Scene ใหม่เสร็จสิ้น
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ยกเลิกการรับ Event เมื่อ Object ถูกปิดหรือทำลาย
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // ฟังก์ชันที่ทำงานเมื่อ Scene ใหม่โหลดเสร็จแล้ว
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckQuestStatus();
    }

    // ฟังก์ชันหลักในการตรวจสอบสถานะเควส
    void CheckQuestStatus()
    {
        // ตรวจสอบว่า Scene ปัจจุบันใช่ Target Scene (Health Zone) หรือไม่
        string currentSceneName = SceneManager.GetActiveScene().name;

        // ถ้า Scene ปัจจุบัน *ไม่ใช่* Health Zone
        if (currentSceneName != TargetSceneName)
        {
            // เปิดข้อความเควส (Objective: ไปหาหมอ)
            if (healthZoneQuestUI != null)
            {
                healthZoneQuestUI.SetActive(true);
            }
        }
        // ถ้า Scene ปัจจุบัน *คือ* Health Zone
        else
        {
            // ปิดข้อความเควส (เพราะผู้เล่นมาถึงแล้ว)
            if (healthZoneQuestUI != null)
            {
                healthZoneQuestUI.SetActive(false);
            }
        }
    }
}