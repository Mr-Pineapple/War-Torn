using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCoveredNode : Node {
    private Transform target;
    private Transform origin;

    public IsCoveredNode(Transform target, Transform origin) {
        this.target = target;
        this.origin = origin;
    }

    public override NodeState Evaluate() {
        //TODO: Raycast from enemy class moved to here to check if there is something in the way, then return success
        return NodeState.FAILURE;
    }
}
