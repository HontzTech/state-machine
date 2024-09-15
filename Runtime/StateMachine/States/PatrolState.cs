using UnityEngine;

namespace HontzTech.StateMachine.States
{
    /// <summary>
    /// Represents the "Patrolling" state for an enemy.
    /// </summary>
    public class PatrolState : AState
    {
        // Override of the abstract StateType from AState
        public override StateType StateType => StateType.Patrolling;

        // A reference to the enemy controller
        private readonly EnemyController _controller;

        // Speed at which the enemy patrols
        private readonly float _patrolSpeed;

        // Patrol points
        private readonly Transform _pointA;
        private readonly Transform _pointB;

        // Current target point in patrol
        private Transform _targetPoint;

        // Constructor to initialize the controller, patrol speed, and patrol points
        public PatrolState(EnemyController controller, float patrolSpeed, Transform pointA, Transform pointB)
        {
            _controller = controller;

            _patrolSpeed = patrolSpeed;
            _pointA = pointA;
            _pointB = pointB;

            _targetPoint = _pointA;
        }

        // Override of the abstract ExecuteState method from AState. Contains logic for the patrol state
        public override void ExecuteState()
        {
            var direction = Patrol(_controller);
            _controller.RotateTowards(direction);
            _controller.SetVelocity(direction * _patrolSpeed);
        }

        // Private method for patrolling logic, changes target point when close enough
        private Vector3 Patrol(EnemyController controller)
        {
            if (Vector3.Distance(controller.transform.position, _targetPoint.position) <= 0.5f)
            {
                _targetPoint = _targetPoint == _pointA ? _pointB : _pointA;
            }

            return (_targetPoint.position - controller.transform.position).normalized;
        }
    }
}
