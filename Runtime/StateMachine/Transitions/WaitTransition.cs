using DG.Tweening;

namespace ArcaneHeist.Scripts.EnemyBehaviour.Transitions
{
    /// <summary>
    /// WaitTransition class inherits from ATransition. It triggers a transition after waiting for a specified amount of time.
    /// </summary>
    public class WaitTransition : ATransition
    {
        private bool _waitTimePassed;

        // The condition for the transition is if the wait time has passed.
        public override bool TransitionCondition() => _waitTimePassed;

        // Constructor for the class that takes the wait time in seconds.
        public WaitTransition(StateType nextState, float waitTimeInSeconds) : base(nextState)
        {
            DOVirtual.DelayedCall(waitTimeInSeconds, () => { _waitTimePassed = true; });
        }
    }
}
