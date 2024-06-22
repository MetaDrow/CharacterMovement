using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class ClimbState : CharacterState
    {
        public ClimbState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character.Animator.SetBool("Climb", true);
        }

        public override void Exit()
        {
            _character.Animator.SetBool("Climb", false);
        }

        public override void LogicUpdate()
        {
            if (_character.Data._isGrounded)
            {
                _stateMachine.ChangeState(_character.Data._groundState);
            }
        }

        public override void PhysicsUpdate()
        {
            _character.Data._wallClimb = new Vector3(_character.Data._direction.x * _character.Data._climbForceX, _character.Data._climbForceY);
            _character.CharacterController.Move(_character.Data._wallClimb * Time.fixedDeltaTime);
        }
    }
}