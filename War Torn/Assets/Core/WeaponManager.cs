using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    #region Fire Rate
    [SerializeField] float fireRate;
    float fireRateTime;
    [SerializeField] bool semi;
    #endregion

    #region Bullet
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPosition;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    CameraAimManager aim;
    #endregion

    [SerializeField] AudioClip gunshot;
    AudioSource audioSource;
    WeaponAmmo ammo;
    ActionStateManager actions;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<CameraAimManager>();
        ammo = GetComponent<WeaponAmmo>();
        actions = GetComponentInParent<ActionStateManager>();
        fireRateTime = fireRate;
    }

    void Update() {
        if (canFire()) Fire();
    }

    bool canFire() {
        fireRateTime += Time.deltaTime;
        if (fireRateTime < fireRate) return false;
        if (ammo.currentAmmo == 0) return false;
        if (actions.currentState == actions.Reload) return false;
        if (semi && Input.GetKeyDown((KeyCode)GameManager.Controls.shoot)) return true;
        if (!semi && Input.GetKey((KeyCode)GameManager.Controls.shoot)) return true;
        return false;
    }

    void Fire() {
        fireRateTime = 0;
        barrelPosition.LookAt(aim.aimPosition);
        audioSource.PlayOneShot(gunshot);
        ammo.currentAmmo--;
        for (int i = 0; i < bulletsPerShot; i++) {
            GameObject currentBullet = Instantiate(bullet, barrelPosition.position, barrelPosition.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
