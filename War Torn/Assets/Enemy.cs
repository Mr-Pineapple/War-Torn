using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool isInDetectionRadius { get; set; }
    [SerializeField] Transform player;
    [SerializeField] float degreesPerSecond;
    [SerializeField] LayerMask layerMask;

    void Update() {
        if (isInDetectionRadius) {
            LookAtPlayer();
        }
    }

    private void FixedUpdate() {
        RaycastHit hit;
        //Checks if a raycast has hit an object with the layer specified in the inspector
        //Would write the layer manually but who in the world would want to bit shift the index
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Hit Player");
        } else {
            //Drawing the raycast cause I can't fucking see where it's looking otherwise
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        }
    }

    void LookAtPlayer() {
        //Difference between the player position and enemys position to give a direction
        Vector3 directionFromEnemyToTarget = player.position - transform.position;

        //Block the y rotation because why would I want to do some more work with animations
        //Plus the player doesn't jump for the same reason
        directionFromEnemyToTarget.y = 0;

        //Calculates a rotation where the direction 'directionFromEnemyToTarget' would be forward
        Quaternion lookRotation = Quaternion.LookRotation(directionFromEnemyToTarget);

        //Lerp from the current rotation to the desired rotation 
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (degreesPerSecond / 360));
    }
}
