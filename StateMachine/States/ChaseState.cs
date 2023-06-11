namespace ArcaneHeist.Scripts.EnemyBehaviour.States
{
    /// <summary>
    /// Represents the "Chasing" state for an enemy.
    /// </summary>
    public class ChaseState : AState
    {
        // Override of the abstract StateType from AState
        public override StateType StateType => StateType.Chasing;

        // A reference to the enemy controller
        private readonly EnemyController _controller;

        // Speed at which the enemy chases the player
        private readonly float _chaseSpeed;

        // Constructor to initialize the controller and chase speed
        public ChaseState(EnemyController enemyController, float chaseSpeed)
        {
            _controller = enemyController;
            _chaseSpeed = chaseSpeed;
        }

        // Override of the abstract ExecuteState method from AState. Contains logic for the chase state
        public override void ExecuteState()
        {
            var directionTowardsPlayer = (_controller.PlayerPosition - _controller.transform.position).normalized;

            _controller.RotateTowards(directionTowardsPlayer);
            _controller.SetVelocity(directionTowardsPlayer * _chaseSpeed);
        }
    }
}
