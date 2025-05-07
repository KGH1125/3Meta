using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // 따라갈 대상
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
    [SerializeField] private float minX, maxX, minY, maxY;
    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is NULL");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 카메라의 이동 범위를 제한
        float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, offset.z);
    }
}