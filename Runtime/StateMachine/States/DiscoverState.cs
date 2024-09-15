using DG.Tweening;
using UnityEngine;

namespace HontzTech.StateMachine.States
{
    /// <summary>
    /// Represents the "Discovering" state for an enemy.
    /// </summary>
    public class DiscoverState : AState
    {
        // A reference to the enemy controller
        private readonly EnemyController _controller;

        // Override of the abstract StateType from AState
        public override StateType StateType => StateType.Discovering;

        // Constructor to initialize the controller
        public DiscoverState(EnemyController controller)
        {
            _controller = controller;
        }

        // Override of the virtual EnterState method from AState. Contains logic for when the discovering state is entered
        public override void EnterState()
        {
            _controller.SetVelocity(Vector3.zero);
            _controller.transform.DOPunchScale(Vector3.one * 0.3f, 0.2f);
        }
    }
}
