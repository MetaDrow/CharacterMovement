using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class RollState : CharacterState
    {
        private int _rollStateTime;
        public RollState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character.Animator.SetBool("Roll", true);
            _character.Data._isRoll = true;
            _rollStateTime = _character.Data._rollTime;
        }
        public override void HandleInput()
        {

        }
        public override void Exit()
        {
            _character.Data._rollTime = _rollStateTime;
            _character.Data._isRoll = false;
            _character.Animator.SetBool("Roll", false);
            _character.CharacterController.height = 1.15f;
            _character.CharacterController.center = new Vector3(0, 0.7f, 0);
        }

        public override void LogicUpdate()
        {
            RollTime();

            if (_character.Data._isRoll && _character.Data._rollTime != 0)
            {
                _character.CharacterController.height = 0.5f;
                _character.CharacterController.center = new Vector3(0, 0.3f, 0);
            }
        }

        public override void PhysicsUpdate()
        {
            _character.Data._velocity = new Vector3(_character.Data._direction.x * _character.Data._rollForce, _character.Data._gravityVelocity.y);
            _character.CharacterController.Move(_character.Data._velocity * Time.fixedDeltaTime);
        }

        void RollTime()
        {
            if (_character.Data._rollTime != 0)
            {
                _character.Data._rollTime--;
            }
            else
            {
                _stateMachine.ChangeState(_character.Data._runState);
            }
        }
    }
}


