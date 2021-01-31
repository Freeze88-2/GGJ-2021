using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;

    private void Awake()
    {
        canvas.alpha = 1f;
        StartCoroutine(FadeOut());
        DontDestroyOnLoad(this);
    }
    public void StartGame()
    {
        StartCoroutine(FadeIn());
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    private IEnumerator FadeIn()
    {
        while (canvas.alpha < 1)
        {
            canvas.alpha += 0.5f * Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1);
        mainMenu.SetActive(false);
        credits.SetActive(false);
        StartCoroutine(FadeOut(true));
    }
    private IEnumerator FadeOut(bool destroy = false)
    {

        while (canvas.alpha > 0)
        {
            canvas.alpha -= 0.5f * Time.deltaTime;
            yield return null;
        }
        if (destroy)
        {
            Destroy(this.gameObject);
        }
    }
}
