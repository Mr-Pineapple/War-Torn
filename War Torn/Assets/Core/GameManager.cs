using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

/**
 * Used for global game controls
 */
public class GameManager : MonoBehaviour {
    bool isGamePaused;

    void OnApplicationFocus(bool focus) {
        if (focus) Cursor.lockState = CursorLockMode.Locked;
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void pauseGame(bool pause) {
        if (pause) {
            Time.timeScale = 0;
            isGamePaused = true;
        } else {
            Time.timeScale = 1;
            isGamePaused = false;
        }
    }

    public enum Controls {
        crouch = KeyCode.LeftControl,
        run = KeyCode.LeftShift,
        aim = KeyCode.Mouse1,
        shoot = KeyCode.Mouse0,
        reload = KeyCode.R,
        camera = KeyCode.LeftAlt
    }

}
