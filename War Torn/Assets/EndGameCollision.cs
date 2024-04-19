using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCollision : MonoBehaviour {
    [SerializeField] GameObject gameManager;

    private void Start() {
        gameManager = GameObject.Find("# *** Game Manager ***");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Player") {
            gameManager.GetComponent<GameManager>().endGame();
            Debug.LogWarning("OnCollisionEnter");
        }
        Debug.LogWarning("OnTriggerEnter: " + other.gameObject.name);
    }
}
