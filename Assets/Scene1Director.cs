using UnityEngine;
using System.Collections;

public class Scene1Director : MonoBehaviour
{
    public AudioSource ambience;
    public AudioSource narration;

    public EarthMovement earth;

    void Start()
    {
        StartCoroutine(SceneSequence());
    }

    IEnumerator SceneSequence()
    {
        // 0s — ambience starts
        ambience.Play();

        // 5s — narration
        yield return new WaitForSeconds(5f);
        narration.Play();

        // 10s — earth moves
        yield return new WaitForSeconds(5f);
        earth.StartMoving();
    }
}