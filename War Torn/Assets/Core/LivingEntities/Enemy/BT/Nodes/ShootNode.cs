using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class ShootNode : Node {
    private NavMeshAgent agent;
    private Enemy ai;
    private Transform player;

    public ShootNode(NavMeshAgent agent, Enemy ai, Transform player) {
        this.agent = agent;
        this.ai = ai;
        this.player = player;
    }

    public override NodeState Evaluate() {
        agent.isStopped = true;
        ai.transform.LookAt(player);
        Debug.Log("Player Shot");
        return NodeState.SUCCESS;
    }

}
