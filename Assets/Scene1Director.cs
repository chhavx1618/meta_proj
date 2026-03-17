using UnityEngine;
using System.Collections;

public class Scene1Director : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource ambience;
    public AudioSource narration;

    [Header("Earth")]
    public EarthMovement earth;

    [Header("Timing")]
    public float narrationDelay = 5f;
    public float earthStartDelay = 10f;

    void Start()
    {
        StartCoroutine(RunScene());
    }

    IEnumerator RunScene()
    {
        // 0s — Start ambience immediately
        if (ambience != null)
            ambience.Play();

        // 5s — Start narration
        yield return new WaitForSeconds(narrationDelay);

        if (narration != null)
            narration.Play();

        // 10s — Start Earth movement
        yield return new WaitForSeconds(earthStartDelay - narrationDelay);

        if (earth != null)
            earth.StartMoving();
    }
}