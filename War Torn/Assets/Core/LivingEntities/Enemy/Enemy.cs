using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject player;

    private float startingHealth;
    private float currentHealth;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    [SerializeField] private Animator animator;
    Rigidbody rb;

    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform barrelPos;
    

    private NavMeshAgent agent;

    private Node topNode;


    //TODO: more health stuff, clamping the current health from 0 to the startingHealth as well as damage logic


    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Start() {
        currentHealth = startingHealth;
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree() {
        ChaseNode chaseNode = new ChaseNode(player.transform, agent, this, animator);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, player.transform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, player.transform, transform);
        ShootNode shootNode = new ShootNode(agent, this, player.transform);
        HealthNode idle = new HealthNode();

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

        topNode = new Selector(new List<Node> { chaseSequence, shootSequence });
    }

    private void FixedUpdate() {
        topNode.Evaluate();
        if (rb.velocity.magnitude < 0.1) {
            animator.SetBool("isWalking", false);
        }

        


#pragma warning disable CS0618
        RaycastToPlayer();
#pragma warning restore CS0618
    }

    public float GetCurrentHealth() {
        return currentHealth;
    }

    /**
     * Old version of enemy looking at player
     * Moved to behaviour trees above
     * ---------------------------------------------------------------------------------------------------------------
     * Non of the code below is being used by the current project it is only being kept for code optimisation document
     * ---------------------------------------------------------------------------------------------------------------
     */

    [Obsolete("RaycastToPlayer is deprecated, as usage of behavior trees are being implemented.")]
    void RaycastToPlayer() {
        RaycastHit hit;
        //Checks if a raycast has hit an object with the layer specified in the inspector
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (hit.collider.name == "Player") {
                Debug.Log("Hit Player");
            } else {
                return;
            }
        } else {
            //Drawing the raycast cause I can't fucking see where it's looking otherwise
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
        }
    }

    [Obsolete("LookAtPlayer is deprecated, as usage of behavior trees are being implemented.")]
    void LookAtPlayer() {
        //Difference between the player position and enemys position to give a direction
        Vector3 directionFromEnemyToTarget = player.transform.position - transform.position;

        //Block the y rotation because why would I want to do some more work with animations
        //Plus the player doesn't jump for the same reason
        directionFromEnemyToTarget.y = 0;

        //Calculates a rotation where the direction 'directionFromEnemyToTarget' would be forward
        Quaternion lookRotation = Quaternion.LookRotation(directionFromEnemyToTarget);

        //Lerp from the current rotation to the desired rotation
        // 2000 would have been the degrees per second variable which has been removed
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (2000 / 360));
    }
}
