using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {
    
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    public NavMeshSurface navMeshSurface;

    private void Start() {
        currentHealth = maxHealth;
    }

    [ContextMenu("Damage Player")]
    public void hurt() {
        damage(5);
    }

    public void damage(int amount) {
        currentHealth -= amount;
    }

    public int getCurrentHealth() {
        return currentHealth;
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    [ContextMenu("Bake NavMesh")]
    void bake() {
        navMeshSurface.BuildNavMesh();
    }
}
