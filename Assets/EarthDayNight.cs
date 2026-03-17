using UnityEngine;

public class EarthDayNight : MonoBehaviour
{
    public Material earthMat;
    public Texture dayTex;
    public Texture nightTex;

    public float transitionDuration = 5f;
    private float timer = 0f;
    private bool startTransition = false;

    void Start()
    {
        earthMat.SetTexture("_BaseMap", dayTex);
        Invoke("BeginTransition", 3f);
    }

    void BeginTransition()
    {
        startTransition = true;
    }

    void Update()
    {
        if (startTransition)
        {
            timer += Time.deltaTime;
            float t = timer / transitionDuration;

            earthMat.Lerp(
                new Material(earthMat) { mainTexture = dayTex },
                new Material(earthMat) { mainTexture = nightTex },
                t
            );

            if (t >= 1f)
                startTransition = false;
        }
    }
}