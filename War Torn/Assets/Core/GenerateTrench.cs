using UnityEngine;

public class GenerateTrench : MonoBehaviour {

    public GameObject TrenchPrefab;
    public GameObject startingPoint;

    void Start() {
        CreateStartingSection();
    }

    private void CreateStartingSection() {
        Instantiate(TrenchPrefab, new Vector3(startingPoint.transform.position.x - 1.3f,
            startingPoint.transform.position.y + 7f,
            startingPoint.transform.position.z - 6f), Quaternion.identity);
    }
}
