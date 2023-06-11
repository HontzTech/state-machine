using System.Collections.Generic;
using UnityEngine;

namespace HontzTech.StateMachine
{
    /// <summary>
    /// Manages a state machine which runs transitions and states.
    /// </summary>
    public class StateMachine
    {
        // Current active state in the state machine
        private AState _state;

        // Collection of all states available in the state machine, accessible via their type
        private readonly Dictionary<StateType, AState> _states;

        // Collection of all global transitions available in the state machine
        private readonly List<ATransition> _globalTransitions;

        // Default constructor for StateMachine, initializes an empty global transitions list
        public StateMachine()
        {
            _globalTransitions = new List<ATransition>();
        }

        // Overloaded constructor for StateMachine, initializes the global transitions list with provided transitions
        public StateMachine(List<ATransition> globalTransitions)
        {
            _states = new Dictionary<StateType, AState>();
            _globalTransitions = globalTransitions;
        }

        // Adds a new state to the state machine
        public StateMachine AddState(AState newState)
        {
            if (newState == null)
            {
                Debug.LogError($"Tried adding state to state machine but {nameof(newState)} was null");
            }
            else
            {
                _states.Add(newState.StateType, newState);
            }

            return this;
        }

        // Sets the initial state of the state machine
        public StateMachine Initialize(AState initialState)
        {
            SetState(initialState.StateType);
            return this;
        }

        // Executes a tick in the state machine, which checks transitions and execute the current state
        public void Tick()
        {
            if (CheckGlobalTransitions())
                return;

            if (CheckStateTransitions())
                return;

            // Executes current state if no transitions conditions are met
            _state.ExecuteState();
        }

        // Checks all global transitions and applies the first valid one found
        private bool CheckGlobalTransitions()
        {
            foreach (var transition in _globalTransitions)
            {
                if (transition.TransitionCondition())
                {
                    SetState(transition.NextState);
                    return true;
                }
            }

            return false;
        }

        // Checks all current state specific transitions and applies the first valid one found
        private bool CheckStateTransitions()
        {
            foreach (var transition in _state.Transitions)
            {
                if (transition.TransitionCondition())
                {
                    SetState(transition.NextState);
                    return true;
                }
            }

            return false;
        }

        // Sets the next state of the state machine, exiting the current state and entering the new one
        private void SetState(StateType nextStateType)
        {
            if (!_states.TryGetValue(nextStateType, out var nextState))
            {
                throw new KeyNotFoundException($"State {nextStateType} not found.");
            }

            _state?.ExitState();
            _state = nextState;
            _state.EnterState();
        }
    }
}
