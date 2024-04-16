using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node {

    public HealthNode() {
    }

    public override NodeState Evaluate() {
        return NodeState.SUCCESS;
    }
}
