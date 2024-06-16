using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    internal class RunState : CharacterState
    {
        internal RunState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character._characterData._gravityVelocity.y = _character._characterData._gravityValue;
        }

        public override void HandleInput()
        {
            _character._characterData._currentAnimationBlendVector = Vector2.LerpUnclamped(_character._characterData._currentAnimationBlendVector, _character._characterData._direction, _character._characterData._acceleration);
            _character._animator.SetFloat("Direction", _character._characterData._currentAnimationBlendVector.x);
        }

        public override void Exit()
        {
            _character._characterData._isRun = false;
            _character._characterData._gravityVelocity = Vector2.zero;
        }
        public override void LogicUpdate()
        {
            if (_character._characterData._isWall)
            {
                _stateMachine.ChangeState(_character._wallState);
            }

            if (!_character._characterData._isGrounded)
            {
                _stateMachine.ChangeState(_character._airState);
            }

            if (_character._characterData._isJump)
            {
                _stateMachine.ChangeState(_character._jumpState);
            }

            if (_character._characterData._isRoll)
            {
                _stateMachine.ChangeState(_character._rollState);
            }

            if (_character._characterData._direction.x != 0)
            {
                _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._characterData._direction.x, 0, 0));
            }

            if (_character._characterData._direction.x == 0)
            {
                _stateMachine.ChangeState(_character._standingState);
            }

        }

        public override void PhysicsUpdate()
        {
            if (_character._characterData._currentSpeed < _character._characterData._maxSpeed && _character._characterData._direction.x != 0)
            {
                _character._characterData._currentSpeed += _character._characterData._acceleration;
            }

            _character._characterData._velocity = new Vector2(_character._characterData._direction.x * _character._characterData._currentSpeed, _character._characterData._gravityVelocity.y);
            _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);
        }
    }
}




