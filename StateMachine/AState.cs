using System.Collections.Generic;

namespace HontzTech.StateMachine
{
    /// <summary>
    /// An abstract representation of a state in the state machine.
    /// </summary>
    public abstract class AState
    {
        // Abstract property to represent the type of state
        public abstract StateType StateType { get; }

        // A list of transitions associated with this state
        public readonly List<ATransition> Transitions = new();

        // Virtual method called when entering the state, can be overridden in derived classes
        public virtual void EnterState()
        {
        }

        // Virtual method representing the execution of the state, can be overridden in derived classes
        public virtual void ExecuteState()
        {
        }

        // Virtual method called when exiting the state, can be overridden in derived classes
        public virtual void ExitState()
        {
        }

        // Method to add a transition to this state
        public AState AddTransition(ATransition transition)
        {
            Transitions.Add(transition);
            return this;
        }
    }
}
 
