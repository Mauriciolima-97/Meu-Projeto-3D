using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : StateBase
{
    PlayerController player;

    public PlayerMoveState(PlayerController player)
    {
        this.player = player;
    }

    public override void OnStateEnter() { }

    public override void OnStateStay()
    {
        player.transform.Translate(Vector3.forward * player.speed * Time.deltaTime);

        if (!Input.GetKey(KeyCode.W))
            player.stateMachine.SwitchState(PlayerState.Idle);

        if (Input.GetKeyDown(KeyCode.Space))
            player.stateMachine.SwitchState(PlayerState.Jump);
    }

    public override void OnStateExit() { }
}

