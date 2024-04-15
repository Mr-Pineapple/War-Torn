using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node {
    private Transform target;
    private NavMeshAgent agent;
    private Enemy ai;

    public ChaseNode(Transform target, NavMeshAgent agent, Enemy ai) {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate() {
        ai.SetColor(Color.red);
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if(distance > 3f) {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        } else {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
