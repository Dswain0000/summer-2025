using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public PlayerMovementScript playerMovementscript;
    public GameObject retryButton;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        retryButton.SetActive(false);
    }

    public void GameOver()
    {
        if (playerMovementscript != null)
            playerMovementscript.enabled = false;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over!";
        }

        if (retryButton != null)
            retryButton.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
