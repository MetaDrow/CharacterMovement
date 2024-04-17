namespace CharacterStateMachine
{
    internal class StateMachine
    {
        protected internal State _currentState { get; set; }


        protected internal void Initialize(State startState)
        {
            _currentState = startState;
            _currentState.Enter();
        }

        protected internal void ChangeState(State newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}