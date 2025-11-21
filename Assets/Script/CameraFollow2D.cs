using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;      // เอาไว้ลาก Player มาใส่
    public float smoothTime = 0.2f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z   // z ของกล้องไม่เปลี่ยน
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime
        );
    }
}
