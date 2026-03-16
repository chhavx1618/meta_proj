using UnityEngine;

public class GodAuraFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public float distance = 6f;
    public float heightOffset = 0f;
    public float followSpeed = 2f;

    void LateUpdate()
    {
        if (cameraTransform == null) return;

        Vector3 targetPosition =
            cameraTransform.position
            - cameraTransform.forward * distance
            + Vector3.up * heightOffset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        transform.LookAt(cameraTransform.position);
    }
}