using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnApplicationFocus(bool focus) {
        if (focus) Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum Controls {
        crouch = KeyCode.LeftControl,
        run = KeyCode.LeftShift,
        aim = KeyCode.Mouse1,
    }

}
