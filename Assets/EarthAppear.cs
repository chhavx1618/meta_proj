using UnityEngine;

public class EarthAppear : MonoBehaviour
{
    public Transform cameraTransform;
    public float speed = 2f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            cameraTransform.position + cameraTransform.forward * 80f,
            speed * Time.deltaTime
        );
    }
}