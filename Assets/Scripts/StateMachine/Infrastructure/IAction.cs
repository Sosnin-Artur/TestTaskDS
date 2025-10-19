namespace StateMachine.Infrastructure
{    
    public interface IAction<in T> where T : IComponent
    {
        public void SetUp(T setUpObject);
        public void Act(T setUpObject);
    }
}
