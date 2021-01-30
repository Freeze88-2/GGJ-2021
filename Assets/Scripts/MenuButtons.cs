using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
}
