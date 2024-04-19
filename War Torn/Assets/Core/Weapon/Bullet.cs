using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float timeToDestroy;
    [SerializeField] LayerMask enemyLayer;

    void Start() {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject enemy = collision.collider.gameObject;
        if(collision.gameObject.name == "Enemy(Clone)") {
            Destroy(enemy);
            Destroy(gameObject);
        }
    }

}
