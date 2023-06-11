using System.Collections.Generic;
using HontzTech.StateMachine.States;
using HontzTech.StateMachine.Transitions;
using UnityEngine;

namespace HontzTech.StateMachine
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyController : MonoBehaviour
    {
        #region Fields

        public const float FieldOfView = 120f;
        private const float RotationSpeed = 720f; // degrees per second

        [Header("Patrol")]
        [SerializeField]
        private float _patrolSpeed = 2f;

        [SerializeField]
        private Transform _pointA;

        [SerializeField]
        private Transform _pointB;

        [Header("Scan")] //Need to check the next 9 lines here.
        public float _rotationSpeed = 100f;

        public float _targetRotation = 160f;

        public float _leftTargetRotation = 160f;

        public float _rightTargetRotation = 160f;

        public bool _isRotating;

        [Header("Chase")]
        [SerializeField]
        private float _chaseSpeed = 4f;

        [SerializeField]
        private float _chaseDistance = 5f;

        public float ChaseDistance => _chaseDistance;

        [SerializeField]
        private PlayerController _playerController;

        public Vector3 PlayerPosition => _playerController.transform.position;

        #endregion

        private StateMachine _stateMachine;

        private void Start()
        {
            SetupStates();
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void SetupStates()
        {
            var globalTransitions = new List<ATransition>();

            var spotPlayerTransition = new SpotPlayerTransition(this, StateType.Discovering);

            var patrolState = new PatrolState(this, _patrolSpeed, _pointA, _pointB)
                .AddTransition(spotPlayerTransition);

            var discoverState = new DiscoverState(this)
                .AddWaitTransition(StateType.Chasing, 1f);

            var chaseState = new ChaseState(this, _chaseSpeed)
                .AddTransition(new CustomTransition(StateType.Patrolling,
                    () => Vector3.Distance(_playerController.transform.position, transform.position) > 5));

            var scanState = new ScanState(this, 4f)
                .AddTransition(spotPlayerTransition);

            _stateMachine = new StateMachine(globalTransitions)
                .AddState(patrolState)
                .AddState(discoverState)
                .AddState(chaseState)
                .AddState(scanState)
                .Initialize(scanState);
        }

        public void SetVelocity(Vector3 newVelocity)
        {
            Timeline.rigidbody.velocity = newVelocity;
        }

        public void RotateTowards(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;
            var toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Timeline.deltaTime);
        }
    }
}