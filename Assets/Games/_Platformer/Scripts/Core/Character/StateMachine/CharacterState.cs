using Platformer.Character;
using UnityEngine;

namespace CharacterFiniteStateMachine
{
    public abstract class CharacterState
    {
        private protected CharacterStateMachine _stateMachine;
        private protected IPlayer _character;
        public CharacterState(IPlayer character, CharacterStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _character = character;
        }

        public virtual void Enter()
        {

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
    }
}


