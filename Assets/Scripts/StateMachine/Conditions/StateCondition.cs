using StateMachine.Mono;
using StateMachine.ScriptableObjects;
using UnityEngine;

namespace StateMachine.Conditions
{
    [CreateAssetMenu(menuName = "Scriptable State Machine/Conditions/StateCondition", fileName = "new StateCondition")]
    public class StateCondition : ScriptableCondition
    {
	    [SerializeField] private bool _state;
	    
    	public override bool Verify(StateComponent statesComponent)
    	{
    		return _state;
    	}
    }
}