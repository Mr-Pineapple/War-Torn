using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node {
    private Enemy ai;
    private float threshold;

    public HealthNode(Enemy ai, float threshold) {
       this.ai = ai;
        this.threshold = threshold;
    }

    public override NodeState Evaluate() {
        //return ai.GetCurrentHealth() <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;

        if(ai.GetCurrentHealth() <= threshold) {
            return NodeState.SUCCESS;
        } else {
            return NodeState.FAILURE;
        }
    }
}
