using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : StateBase
{
    PlayerController player;

    bool jumped;

    public PlayerJumpState(PlayerController player)
    {
        this.player = player;
    }

    public override void OnStateEnter()
    {
        jumped = false;
    }

    public override void OnStateStay()
    {
        if (!jumped)
        {
            player.rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
            jumped = true;
        }

        if (player.rb.velocity.y <= 0)
            player.stateMachine.SwitchState(PlayerState.Idle);
    }

    public override void OnStateExit() { }
}

