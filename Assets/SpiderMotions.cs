using UnityEngine;

public class SpiderVRController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    private bool isWalking = false;

    [Header("Look Around")]
    public float lookDuration = 3f;
    public float lookAngle = 20f;     // increased
    public float lookSpeed = 0.4f;    // slow & creepy
    public Transform head;

    [Header("Camera")]
    public Transform vrCamera;
    public Vector3 cameraOffset = new Vector3(0, 0.5f, 0.3f);

    [Header("Head Bob")]
    public float bobAmount = 0.03f;
    public float bobSpeed = 4f;

    private float timer = 0f;
    private Vector3 camStartPos;

    void Start()
    {
        if (vrCamera != null)
        {
            vrCamera.SetParent(transform);
            vrCamera.localPosition = cameraOffset;
            vrCamera.localRotation = Quaternion.identity;

            camStartPos = vrCamera.localPosition;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // -------- LOOK AROUND (MORE NATURAL) --------
        if (timer < lookDuration)
        {
            float yaw = Mathf.Sin(Time.time * lookSpeed) * (lookAngle * 1.8f);
            float pitch = Mathf.Cos(Time.time * lookSpeed * 0.7f) * (lookAngle * 0.6f);

            // slight randomness
            float noise = Mathf.PerlinNoise(Time.time, 0f) * 2f - 1f;
            yaw += noise * 5f;

            Quaternion lookRot = Quaternion.Euler(pitch, yaw, 0);

            if (head != null)
                head.localRotation = lookRot;
            else
                transform.localRotation = lookRot;
        }
        else
        {
            if (!isWalking)
            {
                if (head != null)
                    head.localRotation = Quaternion.identity;

                isWalking = true;
            }

            // -------- FORWARD MOVEMENT --------
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            // -------- SUBTLE HEAD BOB --------
            if (vrCamera != null)
            {
                float bob = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
                vrCamera.localPosition = camStartPos + new Vector3(0, bob, 0);
            }
        }
    }
}