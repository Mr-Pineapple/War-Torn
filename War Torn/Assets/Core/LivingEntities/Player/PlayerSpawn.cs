using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Zack
 */
public class PlayerSpawn : MonoBehaviour {
    [SerializeField] private GameObject player;
    private Vector3 vector;

    private void Start() {
        Instantiate(player, gameObject.transform);
    }
}
