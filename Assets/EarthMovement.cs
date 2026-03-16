using UnityEngine;

public class EarthMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public float duration = 30f;

    float timer = 0f;
    bool moving = false;

    public void StartMoving()
    {
        moving = true;
    }

    void Update()
    {
        if (!moving) return;

        timer += Time.deltaTime;

        float t = timer / duration;

        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
    }
}