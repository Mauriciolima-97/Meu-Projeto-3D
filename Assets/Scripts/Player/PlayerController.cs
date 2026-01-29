using UnityEngine;
using Ebac.StateMachine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    public Rigidbody rb;

    public StateMachine<PlayerState> stateMachine;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        stateMachine = new StateMachine<PlayerState>();
        stateMachine.Init();

        stateMachine.RegisterStates(PlayerState.Idle, new PlayerIdleState(this));
        stateMachine.RegisterStates(PlayerState.Move, new PlayerMoveState(this));
        stateMachine.RegisterStates(PlayerState.Jump, new PlayerJumpState(this));

        stateMachine.SwitchState(PlayerState.Idle);
    }
    void Update()
    {
        stateMachine.Tick();
    }


}
