using UnityEngine;

namespace HontzTech.StateMachine.Transitions
{
    /// <summary>
    /// PlayerEnterTriggerTransition class inherits from ATransition. It triggers a transition when a player enters a trigger.
    /// </summary>
    public class PlayerEnterTriggerTransition : ATransition
    {
        private readonly TrapController _trapController;
        private bool _playerEnteredTrigger;

        // The condition for the transition is whether the player has entered the trigger.
        public override bool TransitionCondition() => _playerEnteredTrigger;

        // Constructor for the class that takes TrapController instance.
        public PlayerEnterTriggerTransition(StateType nextState, TrapController trapController) : base(nextState)
        {
            _trapController = trapController;
            _trapController.PlayerEnteredTrigger += OnPlayerEnteredTrigger;
        }

        // Private method to handle the PlayerEnteredTrigger event.
        private void OnPlayerEnteredTrigger()
        {
            Debug.Log("Player entered trigger");
            _playerEnteredTrigger = true;
            _trapController.PlayerEnteredTrigger -= OnPlayerEnteredTrigger;
        }
    }
}
