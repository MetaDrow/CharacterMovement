using UnityEngine.InputSystem;
using UnityEngine;

namespace CharacterStateMachine
{
    internal abstract class State
    {
        #region  Params
        private protected StateMachine _stateMachine;
        private protected Character _character;

        private protected InputAction _jumpAction;
        private protected InputAction _runAction;
        private protected InputAction _dashAction;
        #endregion
        protected internal State(Character character, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _character = character;

            _jumpAction = _character._playerInput.actions["Jump"];
            _runAction = _character._playerInput.actions["Move"];
            _dashAction = _character._playerInput.actions["Dash"];
        }
        #region  Methods
        public virtual void Enter()
        {
             Debug.Log("enter state: " + this.ToString());
        }

        public virtual void Exit()
        {

        }
        public virtual void LogicUpdate()
        {

        }
        public virtual void PhysicsUpdate()
        {

        }
        public virtual void HandleInput()
        {

        }
        #endregion
    }
}


