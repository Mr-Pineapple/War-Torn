using UnityEngine;

public class CameraAimManager : MonoBehaviour {
    [SerializeField] float mouseSensitivity = 1;
    float xAxis, yAxis;
    [SerializeField] Transform cameraFollowPosition;

    void Update() {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
    }

    void LateUpdate() {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }
}
