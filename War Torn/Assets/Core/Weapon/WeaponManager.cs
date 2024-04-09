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
    [SerializeField] public Vector3 leftHandIKPosition;
    CameraAimManager aim;
    #endregion

    [SerializeField] AudioClip gunshot;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public WeaponAmmo ammo;
    ActionStateManager actions;

    WeaponRecoil recoil;
    public Transform leftHandTarget, leftHandHint;
    WeaponClassManager weaponClass;


    void Start() {
        aim = GetComponentInParent<CameraAimManager>();
        actions = GetComponentInParent<ActionStateManager>();
        fireRateTime = fireRate;
    }

    private void OnEnable() {
        if(weaponClass == null) {
            weaponClass = GetComponentInParent<WeaponClassManager>();
            ammo = GetComponent<WeaponAmmo>();
            audioSource = GetComponent<AudioSource>();
            recoil = GetComponent<WeaponRecoil>();
            recoil.recoilFollowPosition = weaponClass.recoilFollowPosition;
        }
        weaponClass.SetCurrentWeapon(this);
    }

    void Update() {
        if (canFire()) Fire();
    }

    bool canFire() {
        fireRateTime += Time.deltaTime;
        if (fireRateTime < fireRate) return false;
        if (ammo.currentAmmo == 0) return false;
        if (actions.currentState == actions.Reload) return false;
        if (actions.currentState == actions.Swap) return false;
        if (semi && Input.GetKeyDown((KeyCode)GameManager.Controls.shoot)) return true;
        if (!semi && Input.GetKey((KeyCode)GameManager.Controls.shoot)) return true;
        return false;
    }

    void Fire() {
        fireRateTime = 0;
        barrelPosition.LookAt(aim.aimPosition);
        audioSource.PlayOneShot(gunshot);
        recoil.TriggerRecoil();
        ammo.currentAmmo--;
        for (int i = 0; i < bulletsPerShot; i++) {
            GameObject currentBullet = Instantiate(bullet, barrelPosition.position, barrelPosition.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPosition.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
