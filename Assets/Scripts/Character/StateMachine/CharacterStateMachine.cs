namespace CharacterFiniteStateMachine
{
    internal class CharacterStateMachine
    {
        protected internal CharacterState _currentState { get; set; }

        protected internal void Initialize(CharacterState startState)
        {
            _currentState = startState;
            _currentState.Enter();
        }

        protected internal void ChangeState(CharacterState newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}