namespace ArcaneHeist.Scripts.EnemyBehaviour.States
{
    /// <summary>
    /// Represents the "Idle" state for an enemy.
    /// </summary>
    public class IdleState : AState
    {
        // Override of the abstract StateType from AState
        public override StateType StateType => StateType.Idle;

        // No specific implementation is needed for Idle state in this case as it doesn't have unique behaviors
    }
}
