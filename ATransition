namespace HontzTech.StateMachine
{
    /// <summary>
    /// An abstract representation of a transition between different states.
    /// </summary>
    public abstract class ATransition
    {
        // The type of the next state to transition to
        public StateType NextState { get; }

        // Constructor to set the next state at initialization time
        protected ATransition(StateType nextState)
        {
            NextState = nextState;
        }

        // An abstract method that must be implemented in derived classes to determine the condition for the transition
        public abstract bool TransitionCondition();
    }
}
