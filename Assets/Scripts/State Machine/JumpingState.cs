using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseState
{
    public float doubleTapTime = 1f;
    private float elapsedTime;
    private int pressCount;

    public JumpingState(PlayerStateMachine psm) : base("Jumping", psm) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (playerController.IsGrounded() && playerController.GetVerticalVelocity() < 0)
        {
            playerStateMachine.ChangeState(playerStateMachine.groundedState);
        }


    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        playerController.Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerController.superJumps > 0)
                pressCount++;
            // if they pressed at least once
            if (pressCount > 0)
            {
                // count the time passed
                elapsedTime += Time.deltaTime;

                // if the time elapsed is greater than the time limit
                if (elapsedTime > doubleTapTime)
                {
                    resetPressTimer();
                }
                else if (pressCount == 1) // otherwise if the press count is 2
                {
                    // double pressed within the time limit
                    playerStateMachine.ChangeState(playerStateMachine.superJumpingState);
                    playerController.SuperJump();
                    playerController.superJumps--;
                    playerController.playerText.SetText("Remaining Super Jumps: " + playerController.superJumps);

                    resetPressTimer();
                }
            }
        }


    }

    private void resetPressTimer()
    {
        pressCount = 0;
        elapsedTime = 0;
    }
}
