namespace StateMachine.Infrastructure
{    
    public interface ICondition<in T> where T : IComponent
    {
        public void SetUp(T setUpObject);
        public void Act(T setUpObject);
    }
}
