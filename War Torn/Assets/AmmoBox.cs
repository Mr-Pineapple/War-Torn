using UnityEngine;

public class AmmoBox : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<WeaponClassManager>(out WeaponClassManager weaponclass)) {
            WeaponManager currentWeapon = weaponclass.getCurrentWeapon();
            WeaponAmmo ammoClass = currentWeapon.GetComponent<WeaponAmmo>();
            ammoClass.extraAmmo = ammoClass.extraAmmo += 10;
        }
        Destroy(gameObject);
    }
}
