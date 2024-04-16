using UnityEngine;

/**
 * Author: Zack
 */
public class SpikeTrap : TrapBase {
    [SerializeField] static int damage;

    public SpikeTrap(int damageToInflict) : base(damage) { }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        Debug.Log("Entity Walked in a Spike Trap");
    }
}
