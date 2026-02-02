using Ebac.StateMachine;
using UnityEngine;

public class PlayerJumpState : StateBase
{
    PlayerController player;
    float jumpTime = 0.3f;
    float timer;

    public PlayerJumpState(PlayerController player)
    {
        this.player = player;
    }

    public override void OnStateEnter()
    {
        timer = 0f;
        player.rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
    }

    public override void OnStateStay()
    {
        timer += Time.deltaTime;

        if (timer >= jumpTime)
        {
            player.stateMachine.SwitchState(PlayerState.Idle);
        }
    }
}
