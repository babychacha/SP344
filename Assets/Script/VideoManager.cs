using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // 🚩 (1) ต้องมีบรรทัดนี้

public class VideoManager : MonoBehaviour
{
    // ตัวแปรสาธารณะที่ถูกเชื่อมโยงใน Inspector
    public VideoPlayer cprVideoPlayer; 
    public RawImage videoDisplayUI; 
    
    // 🚩 (2) ตรวจสอบชื่อฉากจริง: ต้องตรงกับชื่อไฟล์ฉาก (เช่น post 1)
    public string postTestSceneName = "post 1"; 

    void Start()
    {
        // ซ่อน UI วิดีโอไว้ก่อน
        videoDisplayUI.gameObject.SetActive(false); 
    }

    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม Exit
    public void PlayCPRVideo()
    {
        // 🚩 (3.1) เชื่อมต่อ Event เมื่อวิดีโอเล่นจบ
        // ลบ Event เก่าออกก่อนเสมอ เพื่อป้องกันการเรียกซ้ำ
        cprVideoPlayer.loopPointReached -= OnVideoFinished; 
        cprVideoPlayer.loopPointReached += OnVideoFinished; 

        // แสดง UI และเริ่มเล่น
        videoDisplayUI.gameObject.SetActive(true);
        cprVideoPlayer.Play();
    }

    // 🚩 (3.2) ฟังก์ชันนี้จะถูกเรียกโดยอัตโนมัติเมื่อวิดีโอเล่นจบ
    void OnVideoFinished(VideoPlayer vp) 
    {
        Debug.Log("Video Finished! Loading new scene: " + postTestSceneName);
        
        // 1. ซ่อน UI วิดีโอ
        videoDisplayUI.gameObject.SetActive(false);
        
        // 2. สั่งให้เปลี่ยนฉากไปยังฉาก Post Test
        SceneManager.LoadScene(postTestSceneName);
    }
}