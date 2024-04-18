using UnityEngine;

public class TrapGenerator : MonoBehaviour {
    [SerializeField] GameObject trap;
    [SerializeField] float minRangeX, maxRangeX, minRangeZ, maxRangeZ;

    private void Start() {
        Vector3 randomPosition = new Vector3(gameObject.transform.localPosition.x + Random.Range(maxRangeX, minRangeX), 0, gameObject.transform.localPosition.z + Random.Range(maxRangeZ, minRangeZ));
        Instantiate(trap, randomPosition, gameObject.transform.rotation * Quaternion.identity * gameObject.transform.localRotation);
    }
}
