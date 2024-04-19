using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] LayerMask bulletLayer;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Shot Enemy");
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Shot Enemy");
    }
}
