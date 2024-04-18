using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject gameManager;

    private void Start() {
        if(gameManager.GetComponent<GameManager>().isGamePaused) {
            canvas.gameObject.SetActive(false);
        }
    }

    public void PauseGame() {
        canvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame() {
        canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager.GetComponent<GameManager>().pauseGame(false);
    }

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
