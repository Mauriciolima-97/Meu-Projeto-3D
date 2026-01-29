using UnityEngine;
using Ebac.StateMachine;

public class PlayerIdleState : StateBase
{
    PlayerController player;

    public PlayerIdleState(PlayerController player)
    {
        this.player = player;
    }

    public override void OnStateStay()
    {
        if (Input.GetKey(KeyCode.W))
            player.stateMachine.SwitchState(PlayerState.Move);

        if (Input.GetKeyDown(KeyCode.Space))
            player.stateMachine.SwitchState(PlayerState.Jump);
    }
}
