using System;

namespace HontzTech.StateMachine.Transitions
{
    /// <summary>
    /// CustomTransition class inherits from ATransition. It allows for a custom condition to be set for the transition.
    /// </summary>
    public class CustomTransition : ATransition
    {
        // A function that checks the condition for the transition.
        private readonly Func<bool> _condition;

        // This transition condition is defined by a provided function.
        public override bool TransitionCondition() => _condition.Invoke();

        // Constructor for the class that takes a function as a condition for the transition.
        public CustomTransition(StateType nextState, Func<bool> condition) : base(nextState)
        {
            _condition = condition;
        }
    }
}
