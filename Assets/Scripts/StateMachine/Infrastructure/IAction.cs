namespace StateMachine.Infrastructure
{    
    public interface IAction<in T> where T : IComponent
    {
        public void SetUp(T component);
        public void Act(T component);
    }
}
