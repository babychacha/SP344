using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToHealth : MonoBehaviour
{
    public string healthSceneName = "ศูนย์อนามัย";   // ชื่อซีนอนามัยของน้อง

    public void OnClickExit()
    {
        // บอกว่า pre-test / quiz ทำเสร็จแล้ว
        PlayerPrefs.SetInt("PreTestDone", 1);

        // เด้งกลับไปที่อนามัย
        SceneManager.LoadScene(healthSceneName);
    }
}
