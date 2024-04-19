using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {
    public GameObject player;
    public GameObject ammoText;
    public GameObject healthText;

    private void Update() {
        float ammo = player.GetComponent<WeaponClassManager>().getCurrentWeapon().ammo.currentAmmo;
        float maxAmmo = player.GetComponent<WeaponClassManager>().getCurrentWeapon().ammo.extraAmmo;
        ammoText.GetComponent<TMPro.TextMeshProUGUI>().text = ammo + " / " + maxAmmo;

        float health = player.GetComponent<Player>().getCurrentHealth();
        healthText.GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + health;
    }
}
