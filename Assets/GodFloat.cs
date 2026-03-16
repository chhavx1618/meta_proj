using UnityEngine;

public class GodFloat : MonoBehaviour
{
    public float floatSpeed = 0.2f;
    public float floatAmount = 0.3f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + 
            new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
    }
}