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

    public Transform aimPosition;
    [SerializeField] float aimSmoothSpeed = 20;
    [SerializeField] LayerMask aimMask;

    float xFollowPosition;
    float yFollowPosition, ogYPosition;
    [SerializeField] float crouchCameraHeight = 0.6f;
    [SerializeField] float shoulderSwapSpeed = 10;
    MovementManager moving;
    [SerializeField] GameObject gameManager;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        moving = GetComponent<MovementManager>();
        xFollowPosition = cameraFollowPosition.localPosition.x;
        ogYPosition = cameraFollowPosition.localPosition.y;
        yFollowPosition = ogYPosition;

        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = virtualCamera.m_Lens.FieldOfView;

        animator = GetComponent<Animator>();
        SwitchState(Hip);

        aimPosition = GameObject.Find("AimPosition").transform;
    }

    void Update() {
        if (gameManager.GetComponent<GameManager>().isGamePaused) return;
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        yAxis = Mathf.Clamp(yAxis, -50, 80);

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);

        currentState.UpdateState(this);

        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask)) {
            aimPosition.position = Vector3.Lerp(aimPosition.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }

        MoveCamera();
    }

    void LateUpdate() {
        cameraFollowPosition.localEulerAngles = new Vector3(yAxis, cameraFollowPosition.localEulerAngles.y, cameraFollowPosition.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    void MoveCamera() {
        if (Input.GetKeyDown((KeyCode)GameManager.Controls.camera)) xFollowPosition = -xFollowPosition;
        if (moving.currentState == moving.Crouch) yFollowPosition = crouchCameraHeight;
        else yFollowPosition = ogYPosition;

        Vector3 newFollowPosition = new Vector3(xFollowPosition, yFollowPosition, cameraFollowPosition.localPosition.z);
        cameraFollowPosition.localPosition = Vector3.Lerp(cameraFollowPosition.localPosition, newFollowPosition, shoulderSwapSpeed * Time.deltaTime);
    }

}
