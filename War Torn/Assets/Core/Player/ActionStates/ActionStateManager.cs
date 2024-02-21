using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour {
    ActionBaseState currentState;
    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();

    public GameObject currentWeapon;
    [HideInInspector] public WeaponAmmo ammo;
    AudioSource audioSource;

    [HideInInspector] public Animator animator;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;

    void Start() {
        SwitchState(Default);
        ammo = currentWeapon.GetComponent<WeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        currentState.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public void WeaponReloaded() {
        ammo.Reload();
        SwitchState(Default);
    }

    public void MagOut() {
        audioSource.PlayOneShot(ammo.magOutSound);
    }

    public void MagIn() {
        audioSource.PlayOneShot(ammo.magInSound);
    }

    public void ReleaseSlide() {
        audioSource.PlayOneShot(ammo.releaseSlideSound);
    }
}
