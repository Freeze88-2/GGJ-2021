using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using System.Collections;

public class Light : MonoBehaviour
{
    private Light2D fire;
    private float startIntesity;
    private float startRangeOuter;
    private float startRangeInner;
    private float timer;
    private float lifePercentage;

    public float LifePercentage 
    {
        get => lifePercentage;
        set
        {
            lifePercentage = value;
            lifePercentage = Mathf.Clamp(lifePercentage,0,1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LifePercentage = 1f;
        fire = GetComponent<Light2D>();

        startIntesity = fire.intensity;
        startRangeOuter = fire.pointLightOuterRadius;
        startRangeInner = fire.pointLightInnerRadius;
    }

    // Update is called once per frame
    void Update()
    {
        LifePercentage -= 0.02f * Time.deltaTime;

        timer += Random.Range(1f, 3f) * Time.deltaTime;
        fire.intensity = (Mathf.Sin(timer) / 3) + startIntesity;

        fire.pointLightOuterRadius = Mathf.Lerp(fire.pointLightOuterRadius,startRangeOuter * LifePercentage, 0.2f);
        fire.pointLightInnerRadius = Mathf.Lerp(fire.pointLightInnerRadius,startRangeInner * LifePercentage, 0.2f);

        if (lifePercentage <= 0)
        {
            StartCoroutine(LoseGame());
        }
    }

    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(1f);

        if (lifePercentage <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
