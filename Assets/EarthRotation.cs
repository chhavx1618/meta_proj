using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 2f * Time.deltaTime);
    }
}