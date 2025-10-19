namespace StateMachine.Infrastructure
{    
    public interface ICondition<in T> where T : IComponent
    {
        public void SetUp(T component);
        public bool Verify(T component);
    }
}
