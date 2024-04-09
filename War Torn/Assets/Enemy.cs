using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] public bool canSeePlayer { get; set; }
    [SerializeField] Transform player;
    [SerializeField] float degreesPerSecond;


    void Update() {
        if (canSeePlayer) {

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
