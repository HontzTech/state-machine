using UnityEngine;
using DG.Tweening;

namespace ArcaneHeist.Scripts.EnemyBehaviour.States
{
    public class ScanState : AState
    {
        public override StateType StateType => StateType.Scanning;

        private readonly EnemyController _controller;

        // _scanSpeed: A float value that determines the speed of the scanning motion
        private readonly float _scanSpeed;

        // _scanningLeft: A boolean value indicating whether the enemy is currently scanning to the left
        private bool _scanningLeft;

        // _leftDirection and _rightDirection: Vector3 instances indicating the directions for scanning left and right
        private readonly Vector3 _leftDirection;
        private readonly Vector3 _rightDirection;

        // _scanTween: A Tween instance that manages the smooth transition of the scanning motion
        private Tween _scanTween;

        // The constructor for the ScanState class
        public ScanState(EnemyController controller, float scanSpeed)
        {
            _controller = controller;
            _scanSpeed = scanSpeed;

            // Calculate the left and right directions based on the enemy's current forward direction
            var forward = _controller.transform.forward;
            _leftDirection = Quaternion.Euler(0, -90, 0) * forward;
            _rightDirection = Quaternion.Euler(0, 90, 0) * forward;
        }

        public override void EnterState()
        {
            // Initialize the scanning direction to left
            _scanningLeft = true;

            // Start scanning towards the left direction
            StartScanning(_leftDirection);
        }

        // The method to run in every frame while the enemy is in the scanning state
        public override void ExecuteState()
        {
            // If the scanning motion has completed
            if (_scanTween.IsComplete())
            {
                // Switch the scanning direction
                _scanningLeft = !_scanningLeft;

                // Determine the next scanning direction based on the _scanningLeft flag
                var targetDirection = _scanningLeft ? _leftDirection : _rightDirection;

                // Start scanning towards the new direction
                StartScanning(targetDirection);
            }
        }

        // Method to start scanning towards a specified direction
        private void StartScanning(Vector3 targetDirection)
        {
            // Rotate the enemy's forward direction towards the target direction at a given speed
            // The _tweenComplete flag is set to true when the rotation is complete
            _scanTween = _controller.transform.DORotateQuaternion(Quaternion.LookRotation(targetDirection), _scanSpeed)
                .SetAutoKill(false);
        }

        // The method to run when the enemy exits the scanning state
        public override void ExitState()
        {
            // If the scanning motion is still in progress, stop it
            _scanTween?.Kill();
        }
    }
}
