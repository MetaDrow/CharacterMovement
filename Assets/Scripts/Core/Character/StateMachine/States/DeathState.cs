using Platformer.Character;

namespace CharacterFiniteStateMachine
{
    public class DeathState : CharacterState
    {
        public DeathState(IPlayer character, CharacterStateMachine stateMachine) : base(character, stateMachine)
        {
        }
    }
}