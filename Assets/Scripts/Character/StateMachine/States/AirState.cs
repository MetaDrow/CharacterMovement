using UnityEngine;
using Platformer.Character;

namespace CharacterFiniteStateMachine
{

    internal class AirState : CharacterState
    {
        internal AirState(Character character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            _character._animator.SetBool("Jump", true);
        }

        public override void Exit()
        {
            _character._animator.SetBool("Jump", false);
        }

        public override void HandleInput()
        {

        }

        public override void LogicUpdate()
        {

            if (_character._characterData._isJump && _character._characterData._jumpCount != _character._characterData._jumpAmount)
            {
                _stateMachine.ChangeState(_character._jumpState);
            }

            if (_character._characterData._isCeiling)
            {
                _stateMachine.ChangeState(_character._airState);
            }

            if (_character._characterData._isGrounded)
            {
                _stateMachine.ChangeState(_character._groundState);
            }

            if (_character._characterData._isWallTop && _character._characterData._direction.x != 0)
            {
                _stateMachine.ChangeState(_character._climbState);
            }

            if (_character._characterData._direction.x != 0)
            {
                _character._characterController.transform.rotation = Quaternion.LookRotation(new Vector3(_character._characterData._direction.x, 0, 0));
            }
        }

        public override void PhysicsUpdate()
        {

            if (_character._characterData._isWall)
            {
                _stateMachine.ChangeState(_character._wallState);
            }

            if (_character._characterData._gravityVelocity.y > _character._characterData._gravityValue)
            {
                _character._characterData._gravityVelocity.y += _character._characterData._gravityValue * _character._characterData._gravityScale * Time.fixedDeltaTime;
            }

            if ((_character._characterData._currentSpeed < _character._characterData._maxSpeed && _character._characterData._direction.x > 0f) || _character._characterData._currentSpeed < _character._characterData._maxSpeed && _character._characterData._direction.x < 0f)
            {
                _character._characterData._currentSpeed += _character._characterData._acceleration;
            }

            _character._characterData._velocity = new Vector2(_character._characterData._direction.x * _character._characterData._currentSpeed, _character._characterData._gravityVelocity.y);
            _character._characterController.Move(_character._characterData._velocity * Time.fixedDeltaTime);
        }
    }

}