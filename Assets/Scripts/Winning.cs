using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WinGame());
        }
    }

    private IEnumerator WinGame()
    {
        Time.timeScale = 0;
        while (canvas.alpha < 1)
        {
            canvas.alpha += 0.5f * Time.unscaledDeltaTime;
            yield return null;
        }

        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
