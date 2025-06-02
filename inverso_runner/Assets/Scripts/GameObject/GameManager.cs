using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("Game Over activado por: " + UnityEngine.StackTraceUtility.ExtractStackTrace());
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    //public void GameOver()
    //{
    //    Debug.Log("Game Over");
    //    if (gameOverPanel != null)
    //    {
    //        gameOverPanel.SetActive(true);
    //        Time.timeScale = 0f; // Pausa el juego
    //    }
    //}

    public void Restart()
    {
        Debug.Log("Reiniciar activado");
        Debug.Log("Reiniciar (versión LoadSceneAsync)");
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    //private IEnumerator RestartCoroutine()
    //{
    //    Time.timeScale = 1f;
    //    yield return null; // permite aplicar el cambio de Time.timeScale
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
