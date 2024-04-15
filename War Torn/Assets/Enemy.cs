using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public bool isInDetectionRadius { get; set; }
    [SerializeField] Transform player;
    [SerializeField] float degreesPerSecond;

    private float startingHealth;
    private float currentHealth;
    private float lowHealthThreshold;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    private Material material;

    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;


    //TODO: more health stuff, clamping the current health from 0 to the startingHealth as well as damage logic

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponent<MeshRenderer>().material;
    }

    private void Start() {
        currentHealth = startingHealth;
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree() {
        ChaseNode chaseNode = new ChaseNode(player, agent, this);
        RangeNode chasingRangeNode = new RangeNode(chasingRange, player, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, player, transform);
        ShootNode shootNode = new ShootNode(agent, this);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

        topNode = new Selector(new List<Node> { shootSequence, chaseSequence });
    }

    void Update() {
        topNode.Evaluate();
        if(topNode.nodeState == NodeState.FAILURE) {
            SetColor(Color.black);
        }
    }

    public float GetCurrentHealth() {
        return currentHealth;
    }

    public void SetColor(Color color) {
        material.color = color;
    }


//    /**
//     * Old version of enemy looking at player
//     * Moved to behaviour trees above, kept for code optimisation document
//     */
//    private void FixedUpdate() {
//#pragma warning disable CS0618
//        RaycastToPlayer();
//#pragma warning restore CS0618
//    }

//    [Obsolete("RaycastToPlayer is deprecated, as usage of behavior trees are being implemented.")]
//    void RaycastToPlayer() {
//        RaycastHit hit;
//        //Checks if a raycast has hit an object with the layer specified in the inspector
//        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
//            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
//            if (hit.collider.name == "Player") {
//                Debug.Log("Hit Player");
//            } else {
//                return;
//            }
//        } else {
//            //Drawing the raycast cause I can't fucking see where it's looking otherwise
//            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
//        }
//    }

//    [Obsolete("LookAtPlayer is deprecated, as usage of behavior trees are being implemented.")]
//    void LookAtPlayer() {
//        //Difference between the player position and enemys position to give a direction
//        Vector3 directionFromEnemyToTarget = player.position - transform.position;

//        //Block the y rotation because why would I want to do some more work with animations
//        //Plus the player doesn't jump for the same reason
//        directionFromEnemyToTarget.y = 0;

//        //Calculates a rotation where the direction 'directionFromEnemyToTarget' would be forward
//        Quaternion lookRotation = Quaternion.LookRotation(directionFromEnemyToTarget);

//        //Lerp from the current rotation to the desired rotation 
//        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (degreesPerSecond / 360));
//    }
}
