using UnityEngine;
using UnityEngine.Tilemaps;

public class check_sizeFloor : MonoBehaviour

{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        if (tilemap == null)
        {
            Debug.LogWarning("ไม่พบ Tilemap บน GameObject นี้");
            return;
        }

        // หาขอบเขตของ tile ที่มีอยู่จริง
        BoundsInt bounds = tilemap.cellBounds;
        Debug.Log($"ขนาดแมพ: กว้าง {bounds.size.x} ช่อง × สูง {bounds.size.y} ช่อง");
    }
}
