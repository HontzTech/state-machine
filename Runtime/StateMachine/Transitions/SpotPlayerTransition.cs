using UnityEngine;

namespace HontzTech.StateMachine.Transitions
{
    /// <summary>
    /// SpotPlayerTransition class inherits from ATransition. It triggers a transition when the enemy spots a player.
    /// </summary>
    public class SpotPlayerTransition : ATransition
    {
        private readonly EnemyController _controller;

        // Constructor for the class that takes EnemyController instance.
        public SpotPlayerTransition(EnemyController enemyController, StateType nextState) : base(nextState)
        {
            _controller = enemyController;
        }

        // The condition for the transition is if the enemy is close to and facing the player.
        public override bool TransitionCondition()
        {
            var position = _controller.transform.position;
            var directionTowardsPlayer = (_controller.PlayerPosition - position).normalized;
            var isCloseToPlayer = Vector3.Distance(position, _controller.PlayerPosition) <= _controller.ChaseDistance;
            var canSeePlayer = Vector3.Angle(_controller.transform.forward, directionTowardsPlayer) <=
                               EnemyController.FieldOfView / 2;
            return isCloseToPlayer && canSeePlayer;
        }
    }
}
