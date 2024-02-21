using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour {
    public int magSize;
    public int extraAmmo;
    [HideInInspector] public int currentAmmo;

    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;

    void Start() {
        currentAmmo = magSize;    
    }

    public void Reload() {
        if (extraAmmo >= magSize) {
            int ammoToReload = magSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        } else if (extraAmmo > 0) {
            if (extraAmmo + currentAmmo > magSize) {
                int leftOverAmmo = extraAmmo + currentAmmo - magSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = magSize;
            } else {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }

}
