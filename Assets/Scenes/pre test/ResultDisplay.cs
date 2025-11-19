using UnityEngine;
using TMPro; 
using UnityEngine.UI; // อาจจำเป็นสำหรับบาง UI Component

public class ResultDisplay : MonoBehaviour
{
    // รับ GameObject ที่มี TextMeshPro (ต้องลากมาใส่ใน Inspector)
    public GameObject scoreDisplayObject; 
    private TextMeshProUGUI scoreTextComponent; 
    
    // รับ GameObject ที่มี Sprite Renderer (ดาวสว่าง 3 ดวง - ต้องลากมาใส่ใน Inspector)
    public GameObject[] filledStarObjects;
    private SpriteRenderer[] filledStarRenderers; 

    void Start()
    {
        // 1. ดึง Component ที่จำเป็น
        GetRequiredComponents();
        
        // 2. ตรวจสอบ ScoreManager
        if (ScoreManager.Instance == null)
        {
            Debug.LogError("ScoreManager Instance not found! Cannot display score. Make sure you start from Scene pre 1.");
            // กำหนดค่าเริ่มต้นเป็น 0 เพื่อป้องกัน Error
            UpdateStarDisplay(1); // แสดง 1 ดาวเป็นค่า Default
            return;
        }

        int finalScore = ScoreManager.currentScore;
        int starCount = ScoreManager.Instance.CalculateStarRating();
        
        // 3. แสดงผลคะแนน: แสดงเฉพาะตัวเลขคะแนนที่ได้ (ตามที่คุณต้องการ)
        if (scoreTextComponent != null) 
        {
            scoreTextComponent.text = finalScore.ToString(); 
            Debug.Log("Final Score to Display: " + finalScore);
        }
        
        // 4. แสดงผลดาว
        UpdateStarDisplay(starCount);
    }
    
    void GetRequiredComponents()
    {
        // A. ดึง TextMeshProUGUI Component สำหรับคะแนน
        if (scoreDisplayObject != null)
        {
            scoreTextComponent = scoreDisplayObject.GetComponent<TMPro.TextMeshProUGUI>();
            if (scoreTextComponent == null) Debug.LogError("Score Text Component (TextMeshProUGUI) not found on the assigned GameObject.");
        }

        // B. ดึง SpriteRenderer Component จาก GameObject ดาว
        if (filledStarObjects.Length > 0)
        {
            filledStarRenderers = new SpriteRenderer[filledStarObjects.Length];
            for (int i = 0; i < filledStarObjects.Length; i++)
            {
                if (filledStarObjects[i] != null)
                {
                    filledStarRenderers[i] = filledStarObjects[i].GetComponent<SpriteRenderer>();
                    if (filledStarRenderers[i] == null) Debug.LogError("SpriteRenderer not found on star object: " + filledStarObjects[i].name);
                }
            }
        }
    }

    void UpdateStarDisplay(int achievedStars)
    {
        if (filledStarRenderers == null || filledStarRenderers.Length < 3)
        {
            Debug.LogError("Filled Star Renderers array is missing or incomplete (expected 3).");
            return;
        }

        for (int i = 0; i < filledStarRenderers.Length; i++)
        {
            if (filledStarRenderers[i] != null)
            {
                // เปิด/ปิด Sprite Renderer ตามจำนวนดาวที่ได้
                filledStarRenderers[i].enabled = (i < achievedStars);
            }
        }
    }
}