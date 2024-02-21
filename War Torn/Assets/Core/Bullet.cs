using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float timeToDestroy;
    float timer;

    void Start() {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(this.gameObject);
    }
}
