# State Machine for Unity
State Machine for Unity is a simple, open-source state machine designed for the Unity game engine. 

This project separates the concern of states and  transitions, creating a more modular and easy-to-follow structure when writing a state machine mostly through code.

# Components
The core of the state machien is found in the root `StateMachine` folder.

- `StateMachine.cs`
- `AState.cs`
- `ATransition.cs`
- `StateType.cs`

The `States` and `Transitions` folder contains example states and transitions, while the `EnemyController.cs` shows and example of how to set up a patrolling guard.

# Setup
First, define the transitions for the state machine. For instance:

```cs
var spotPlayerTransition = new SpotPlayerTransition(this, StateType.Chasing);
var waitTransition = new WaitTransition(this, 10f, StateType.Patrolling);
```

This creates a transition which triggers when the enemy spots the player and transitions into the Chasing state, and a transition which triggers after 10 seconds and transitions into a Patrolling state.

Next, define the states, then add the relevant transitions to the state. For instance:

```cs
var patrolState = new PatrolState(this, _patrolSpeed, _pointA, _pointB)
    .AddTransition(spotPlayerTransition);

var chaseState = new ChaseState(this, _chaseSpeed)
    .AddTransition(waitTransition);
```

Finally, construct the state machine, add the states and choose a state to initialize the state machine:

```cs
_stateMachine = new StateMachine()
    .AddState(patrolState)
    .AddState(chaseState)
    .Initialize(patrolState);
```
