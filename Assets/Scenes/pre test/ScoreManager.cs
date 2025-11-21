using UnityEngine;



public class ScoreManager : MonoBehaviour

{

    // ตัวแปร STATIC สำหรับคะแนนรวม (เข้าถึงได้จากทุกที่)

    public static int currentScore = 0;

   

    // ตัวแปร STATIC สำหรับ Singleton Instance

    public static ScoreManager Instance { get; private set; }



    void Awake()

    {

        // ตั้งค่า Singleton และ DontDestroyOnLoad

        if (Instance == null)

        {

            Instance = this;

            DontDestroyOnLoad(gameObject);

        }

        else

        {

            Destroy(gameObject);

        }

       

        // ตั้งคะแนนเริ่มต้นเป็น 0 ทุกครั้งที่เริ่มเกม

        currentScore = 0;

    }



    // ฟังก์ชันสำหรับเพิ่มคะแนน (เรียกใช้เมื่อตอบถูก/ผิด)

    public void AddScore(int scoreToAdd)

    {

        currentScore += scoreToAdd;

        Debug.Log("คะแนนรวมปัจจุบัน: " + currentScore); // ใช้ตรวจสอบใน Console

    }

   

    // ฟังก์ชันสำหรับคำนวณจำนวนดาว (ตามเกณฑ์ 80, 40)

    public int CalculateStarRating()

    {

        // 80 คะแนน ขึ้นไป = 3 ดาว

        if (currentScore >= 80)

        {

            return 3;

        }

        // 40-79 คะแนน = 2 ดาว

        else if (currentScore >= 40)

        {

            return 2;

        }

        // 0-39 คะแนน = 1 ดาว

        else

        {

            return 1;

        }

    }

}