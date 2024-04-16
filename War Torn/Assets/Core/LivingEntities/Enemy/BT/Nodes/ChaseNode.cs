using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node {
    private Transform target;
    private NavMeshAgent agent;
    private Enemy ai;
    private Animator animator;

    public ChaseNode(Transform target, NavMeshAgent agent, Enemy ai, Animator animator) {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
        this.animator = animator;
    }

    public override NodeState Evaluate() {
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if(distance > 2f) {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            animator.SetBool("isWalking", true);
            return NodeState.RUNNING;
        } else {
            agent.isStopped = true;
            animator.SetBool("isWalking", false);
            return NodeState.SUCCESS;
        }
    }
}
