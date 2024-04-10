using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string sceneTitle)
    {
        StartCoroutine(FadeOut(sceneTitle));
    }

    IEnumerator FadeIn()
    {
        //alpha
        float time = 1f;

        while(time > 0)
        {
            time -= Time.deltaTime;
            float a = fadeCurve.Evaluate(time);
            img.color = new Color(0f,0f,0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string sceneTitle)
    {
        //alpha
        float time = 0f;

        while(time < 1)
        {
            time += Time.deltaTime;
            float a = fadeCurve.Evaluate(time);
            img.color = new Color(0f,0f,0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(sceneTitle);
    }
    
}
