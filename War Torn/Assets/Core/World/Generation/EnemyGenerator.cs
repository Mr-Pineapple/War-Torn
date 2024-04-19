using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] GameObject enemy;
    [SerializeField] float xRange, zRange;

    private void Start() {
        Vector3 randomPosition = new Vector3(gameObject.transform.localPosition.x + Random.Range(-xRange, xRange), 0, gameObject.transform.localPosition.z + Random.Range(-zRange, zRange));
        Instantiate(enemy, randomPosition, gameObject.transform.rotation * Quaternion.identity * gameObject.transform.localRotation, gameObject.transform);
    }
}