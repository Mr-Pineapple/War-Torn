using UnityEngine;

public class AmmoGenerator : MonoBehaviour {
    [SerializeField] GameObject ammoBox;
    [SerializeField] float xRange, zRange;
    [SerializeField] int amountToSpawn;

    private void Start() {
        generateAmmoBox(amountToSpawn);
    }

    void generateAmmoBox(int amount) {
        int random = Random.Range(0, amount);
        int randomRotation = Random.Range(0, 180);
        for (int i = 0; i < amount; i++) {
            Vector3 randomPosition = new Vector3(gameObject.transform.localPosition.x + Random.Range(-xRange, xRange), 0.45f, gameObject.transform.localPosition.z + Random.Range(-zRange, zRange));
            GameObject ammo = Instantiate(ammoBox, randomPosition, Quaternion.Euler(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y * randomRotation, gameObject.transform.localRotation.z), gameObject.transform);
            ammo.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }
}
