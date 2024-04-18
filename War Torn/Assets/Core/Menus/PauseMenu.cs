using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] Canvas canvas;

    public void PauseGame() {
        canvas.gameObject.SetActive(true);
    }

    public void ResumeGame() {
        canvas.gameObject.SetActive(false);
    }

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
