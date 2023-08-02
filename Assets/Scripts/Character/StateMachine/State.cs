namespace CharacterStateMachine
{
    internal abstract class State 
    {
        #region  Params
        private protected StateMachine _stateMachine;
        private protected Character _character;

        #endregion
        protected internal State(Character character, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _character = character;
        }
        #region  Methods
        public virtual void Enter()
        {
            //Debug.Log("enter state: " + this.ToString());
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


