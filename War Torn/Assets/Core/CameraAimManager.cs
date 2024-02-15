using UnityEngine;

public class CameraAimManager : MonoBehaviour {
    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] float mouseSensitivity = 1;
    [SerializeField] Transform cameraFollowPosition;
    float xAxis, yAxis;

    [HideInInspector] public Animator animator;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        SwitchState(Hip);    
    }

    void Update() {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

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
