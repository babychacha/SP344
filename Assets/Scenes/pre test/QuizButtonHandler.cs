using UnityEngine;

using UnityEngine.SceneManagement;



public class QuizButtonHandler : MonoBehaviour

{

    // กำหนดคะแนนที่จะเพิ่ม

    public int scoreValue = 10;

   

    // กำหนดชื่อ Scene ถัดไป

    public string nextSceneName;



    // ฟังก์ชันสำหรับเรียกเมื่อตอบถูก (ผูกกับปุ่มคำตอบที่ถูกต้อง)

    public void HandleCorrectAnswer()

    {

        // 1. เพิ่มคะแนน โดยเรียกผ่าน Singleton Instance

        if (ScoreManager.Instance != null)

        {

            ScoreManager.Instance.AddScore(scoreValue);

        }

        else

        {

            Debug.LogError("ScoreManager Instance not found! Cannot add score.");

        }

       

        // 2. โหลด Scene ถัดไป

        if (!string.IsNullOrEmpty(nextSceneName))

        {

            SceneManager.LoadScene(nextSceneName);

        }

        else

        {

            Debug.LogError("Next scene name is empty. Cannot load scene.");

        }

    }

   

    // ฟังก์ชันสำหรับเรียกเมื่อตอบผิด (ผูกกับปุ่มคำตอบที่ผิด)

    public void HandleWrongAnswer()

    {

        // ไม่ต้องเพิ่มคะแนน

        if (!string.IsNullOrEmpty(nextSceneName))

        {

            SceneManager.LoadScene(nextSceneName);

        }

        else

        {

            Debug.LogError("Next scene name is empty. Cannot load scene.");

        }

    }

}
