using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Used for global game controls
 */
public class GameManager : MonoBehaviour {
    [HideInInspector] public bool isGamePaused;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject endScreen;

    void OnApplicationFocus(bool focus) {
        if (focus) Cursor.lockState = CursorLockMode.Locked;
    }

    void Start() {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        QualitySettings.vSyncCount = 0;
    }

    private void Update() {
        if (Input.GetKeyDown((KeyCode)Controls.pause)) {
            if (isGamePaused) {
                pauseMenu.GetComponent<PauseMenu>().ResumeGame();
                pauseGame(false);
            } else {
                pauseMenu.GetComponent<PauseMenu>().PauseGame();
                pauseGame(true);
            }
        }
    }

    public void pauseGame(bool pause) {
        if (pause) {
            Time.timeScale = 0;
            isGamePaused = true;
        } else {
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }

    public void endGame() {
        SceneManager.LoadScene(0);
    }

    public enum Controls {
        crouch = KeyCode.LeftControl,
        run = KeyCode.LeftShift,
        aim = KeyCode.Mouse1,
        shoot = KeyCode.Mouse0,
        reload = KeyCode.R,
        camera = KeyCode.LeftAlt,
        pause = KeyCode.Escape
    }

}
