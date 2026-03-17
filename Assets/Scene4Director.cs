using UnityEngine;

public class Scene4Director : MonoBehaviour
{
    public Transform earth;
    public float introZoomSpeed = 2f;
    public float targetZ = 40f;

    private bool introDone = false;

    void Update()
    {
        if (!introDone)
        {
            Vector3 pos = earth.position;

            pos.z = Mathf.Lerp(pos.z, targetZ, Time.deltaTime * introZoomSpeed);
            earth.position = pos;

            if (Mathf.Abs(pos.z - targetZ) < 0.1f)
            {
                introDone = true;
            }
        }
    }
}