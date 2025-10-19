namespace StateMachine.Infrastructure
{    
    public interface IStateMachine<T> where T : IComponent
    {
        public IState<T> InitialState { get; }
        public IState<T> EmptyState { get; }

        public IState<T> CheckTransitions(IState<T> stateComponent, IState<T> currentState);
    }
}
