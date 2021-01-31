using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material mat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn());

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }
    private IEnumerator FadeOut()
    {
        float matf = mat.GetFloat("fade");

        while (matf < 1)
        {
            matf += 0.5f * Time.deltaTime;

            mat.SetFloat("fade", matf);

            yield return null;
        }
    }
    private IEnumerator FadeIn()
    {
        float matf = mat.GetFloat("fade");

        while (matf > 0)
        {
            matf -= 0.5f * Time.deltaTime;

            mat.SetFloat("fade", matf);

            yield return null;
        }
    }
}
