using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScreen : MonoBehaviour
{
   public void BackToTheMenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}