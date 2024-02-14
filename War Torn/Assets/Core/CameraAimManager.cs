using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAimManager : MonoBehaviour {
    public Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] Transform cameraFollowPosition;

    void Update() {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    void LateUpdate() {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis.Value, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }
}
