using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public UnityEvent OnPause;
    public UnityEvent OnContinue;

    public void PauseGame()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0f;

        OnPause.Invoke();
    }

    public void ContinueGame()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1f;

        OnContinue.Invoke();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
