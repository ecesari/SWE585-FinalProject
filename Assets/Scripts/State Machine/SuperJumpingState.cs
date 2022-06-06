using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpingState : BaseState
{

	public SuperJumpingState(PlayerStateMachine psm) : base("SuperJumping", psm) { }

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
		
	}
}
