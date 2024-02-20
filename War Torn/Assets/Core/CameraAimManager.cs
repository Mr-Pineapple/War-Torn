using UnityEngine;
using Cinemachine;

public class CameraAimManager : MonoBehaviour {
    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] float mouseSensitivity = 1;
    [SerializeField] Transform cameraFollowPosition;
    float xAxis, yAxis;

    [HideInInspector] public Animator animator;

    [HideInInspector] public CinemachineVirtualCamera virtualCamera;
    public float adsFov = 40;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSmoothSpeed = 10;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = virtualCamera.m_Lens.FieldOfView;

        animator = GetComponentInChildren<Animator>();
        SwitchState(Hip);    
    }

    void Update() {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);

        currentState.UpdateState(this);
    }

    void LateUpdate() {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

}
