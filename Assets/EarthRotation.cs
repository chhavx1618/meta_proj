using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 4f * Time.deltaTime);
    }
}