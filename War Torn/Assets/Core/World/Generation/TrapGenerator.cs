using UnityEngine;

public class TrapGenerator : MonoBehaviour {
    [SerializeField] GameObject trap;
    [SerializeField] float xRange, zRange;

    private void Start() {
        Vector3 randomPosition = new Vector3(gameObject.transform.localPosition.x + Random.Range(-xRange, xRange), 0, gameObject.transform.localPosition.z + Random.Range(-zRange, zRange));
        Instantiate(trap, randomPosition, gameObject.transform.rotation * Quaternion.identity * gameObject.transform.localRotation, gameObject.transform);
    }
}