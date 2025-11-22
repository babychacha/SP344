using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // ตัวแปร STATIC สำหรับคะแนนรวม
    public static int currentScore = 0;

    // Singleton Instance
    public static ScoreManager Instance;

    void Awake()
    {
        // ป้องกันไม่ให้มี ScoreManager ซ้ำกันหลายตัว
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // ให้คงอยู่ทุกซีน
        DontDestroyOnLoad(gameObject);

        // รีเซ็ตคะแนนทุกครั้งที่เริ่ม pre-test
        currentScore = 0;
    }

    // เพิ่มคะแนน
    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Debug.Log("คะแนนรวมปัจจุบัน: " + currentScore);
    }

    // คำนวณจำนวนดาว
    public int CalculateStarRating()
    {
        if (currentScore >= 80)
            return 3;
        else if (currentScore >= 40)
            return 2;
        else
            return 1;
    }
}
