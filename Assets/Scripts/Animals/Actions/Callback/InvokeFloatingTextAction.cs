using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UI;
using UnityEngine;
using Zenject;

namespace Animals.Actions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Actions/InvokeFloatingTextAction", fileName = "new InvokeFloatingTextAction")]
    public class InvokeFloatingTextAction : ScriptableAction
    {
        [SerializeField] 
        private string _message;

        private FloatingText.Factory _factory;

        [Inject]
        public void Construct(FloatingText.Factory factory)
        {
            _factory = factory;
        }

        public override void Act(StateComponent statesComponent)
        {
            _factory.Create(_message, statesComponent.transform.position);
        }
    }
}