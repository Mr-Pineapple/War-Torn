using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootNode : Node {
    private NavMeshAgent agent;
    private Enemy ai;

    public ShootNode(NavMeshAgent agent, Enemy ai) {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate() {
        agent.isStopped = true;
        ai.SetColor(Color.green);
        return NodeState.RUNNING;
    }
}
