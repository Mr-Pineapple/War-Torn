using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {
    bool detected;
    GameObject target;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 100f;
    public float timeToShoot = 1.3f;
    float originalTime;

    void Start() {
        originalTime = timeToShoot;
    }

    void Update() {
        //Used as the debug ray
        Debug.DrawRay(shootPoint.position, shootPoint.forward * 10, Color.green);

        //Raycast from shooting point if player can be seen, should shoot, if it is something else then it will not shoot
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hit, 200)) {
            if(hit.transform.CompareTag("Player")) {
                Debug.Log("Enemy can see player");
            } else {
                Debug.Log("Enemy Can't See player");
            }
        }

        //Enemy looks at player when they are in the detection zone
        if (detected) {
            enemy.LookAt(target.transform);
        }
    }

    //Use fixed update as it is frame dependent, unlike Update
    //Shoots player when the "timer" reaches 0 then resets
    void FixedUpdate() { 
        if(detected) {
            timeToShoot -= Time.deltaTime;

            if(timeToShoot < 0) {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    //When something enters the detection zone, if a player - then set detected to true to run shooting logic
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            detected = true;
            target = other.gameObject;
        }
    }

    //Updates when the entity leaves the detection zone - unassigns the target
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            detected = false;
            target = null;
        }
    }

    //Used when the enemy needs to shoot at the player - only called when they are in the detection zone and can be seen
    private void ShootPlayer() {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
    }
}
