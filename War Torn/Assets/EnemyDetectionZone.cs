using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionZone : MonoBehaviour {
    Enemy enemy;

    private void Start() {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.name == "Player") {
            enemy.isInDetectionRadius = true;
        }
    }

    private void OnTriggerExit(Collider collision) {
        if(collision.gameObject.name == "Player") {
            enemy.isInDetectionRadius = false;
        }
    }
}
