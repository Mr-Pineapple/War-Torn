using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] float fireRate;
    float fireRateTime;
    [SerializeField] bool semi;

    void Start() {
        fireRateTime = fireRate;
    }

    void Update() {
        if (canFire()) Fire();
    }

    bool canFire() {
        fireRateTime += Time.deltaTime;
        if (fireRateTime < fireRate) return false;
        if (semi && Input.GetKeyDown((KeyCode)GameManager.Controls.shoot)) return true;
        if (!semi && Input.GetKey((KeyCode)GameManager.Controls.shoot)) return true;
        return false;
    }

    void Fire() {
        fireRateTime = 0;
        Debug.Log("Fire");
    }
}
