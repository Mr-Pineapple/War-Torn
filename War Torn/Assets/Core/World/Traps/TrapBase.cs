using UnityEngine;

public abstract class TrapBase : MonoBehaviour {
    public int damageToInflict;

    public TrapBase(int damageToInflict) {
       this.damageToInflict = damageToInflict;
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<IDamageable>(out IDamageable entity)) {
            entity.damage(damageToInflict);
        }
    }
}
