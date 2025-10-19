namespace StateMachine.Infrastructure
{
    public interface ITransition<T> 
        where T : IComponent
    {
        public IState<T> OriginState { get; }
        public ICondition<T> Condition { get; }
        public IState<T> TrueState { get; }
        public IState<T> FalseState { get; }
    }
}