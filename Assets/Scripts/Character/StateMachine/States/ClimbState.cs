using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    internal class ClimbState : CharacterState
    {
        public ClimbState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character._animator.SetBool("Climb", true);
        }

        public override void Exit()
        {
            _character._animator.SetBool("Climb", false);
        }

        public override void LogicUpdate()
        {
            if (_character._characterData._isGrounded)
            {
                _stateMachine.ChangeState(_character._groundState);
            }
        }

        public override void PhysicsUpdate()
        {
            _character._characterData._wallClimb = new Vector3(_character._characterData._direction.x * _character._characterData._climbForceX, _character._characterData._climbForceY);
            _character._characterController.Move(_character._characterData._wallClimb * Time.fixedDeltaTime);
        }
    }
}


