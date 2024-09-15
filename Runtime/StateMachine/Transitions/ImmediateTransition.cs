namespace HontzTech.StateMachine.Transitions
{
    /// <summary>
    /// ImmediateTransition class inherits from ATransition. It triggers an immediate transition regardless of the condition.
    /// </summary>
    public class ImmediateTransition : ATransition
    {
        // This transition condition is always true, meaning it will always trigger a transition.
        public override bool TransitionCondition() => true;

        // Constructor for the class.
        public ImmediateTransition(StateType nextState) : base(nextState)
        {
        }
    }
}
