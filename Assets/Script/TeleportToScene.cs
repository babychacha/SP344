using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    [Header("ชื่อซีนปลายทางที่จะวาปไป")]
    public string sceneName;

    [Header("ตำแหน่ง Spawn ในซีนปลายทาง")]
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // บันทึกว่าต้องไปโผล่ตรงไหน
            PlayerPrefs.SetString("SpawnPoint", spawnPointName);

            // โหลดซีน
            SceneManager.LoadScene(sceneName);
        }
    }
}
