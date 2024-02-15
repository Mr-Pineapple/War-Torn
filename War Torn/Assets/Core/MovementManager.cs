using UnityEngine;

public class MovementManager : MonoBehaviour {
    public float moveSpeed = 3;
    [HideInInspector] public Vector3 direction;
    float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePosition;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunState Run = new RunState();
    public CrouchState Crouch = new CrouchState();

    //Currently only used to get and set the CharacterController
    void Start() {
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    void Update() {
        GetDirectionAndMove();
        Gravity();

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    //Moves the player from the axis inputs
    void GetDirectionAndMove() {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        direction = transform.forward * vInput + transform.right * hzInput;
        controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
    }

    //Checks if the player is on the ground
    bool IsGrounded() {
        spherePosition = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePosition, controller.radius - 0.05f, groundMask)) {
            return true;
        } else {
            return false;
        }
    }

    //Moves the player with gravity if they are not on the ground
    void Gravity() {
        if (!IsGrounded()) {
            velocity.y += gravity * Time.deltaTime;
        } else if (velocity.y < 0) {
            velocity.y = -2;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    //Debugging Gizmos
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePosition, controller.radius - 0.05f);
    }

}
