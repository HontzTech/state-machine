# State Machine for Unity

Welcome to State Machine for Unity, a simplified, open-source state machine framework designed exclusively for the Unity game engine. This project aims to separate concerns of states and transitions, which results in a modular and more understandable structure when creating a state machine mainly via coding.

## Table of Contents
1. [Features](#features)
2. [Components](#components)
3. [Setup](#setup)
4. [Usage](#usage)
5. [Contributing](#contributing)
6. [License](#license)

## Features

State Machine for Unity simplifies game state management with these primary features:

- Separation of states and transitions
- Easy-to-follow coding structure
- Example scripts for understanding implementation

## Components
The state machine's core is found within the `StateMachine` folder in the root directory. It includes:

- `StateMachine.cs` - This is the primary class responsible for managing transitions and executing states.
- `AState.cs` - An abstract class representing a state in the state machine.
- `ATransition.cs` - An abstract class representing a transition between different states.
- `StateType.cs` - Enum class to represent the possible types of states.

The `States` and `Transitions` folder contains sample states and transitions. The `EnemyController.cs` provides an example of a patrolling guard setup.

## Setup
To implement a state machine using this framework, follow these steps:

1. **Define Transitions** - Create instances of the required transitions:

```cs
var spotPlayerTransition = new SpotPlayerTransition(this, StateType.Chasing);
var waitTransition = new WaitTransition(this, 10f, StateType.Patrolling);
```

This creates a transition which triggers when the enemy spots the player and transitions into the Chasing state, and a transition which triggers after 10 seconds and transitions into a Patrolling state.

2. **Define States** - Instantiate your states and add the relevant transitions:

```cs
var patrolState = new PatrolState(this, _patrolSpeed, _pointA, _pointB)
    .AddTransition(spotPlayerTransition);

var chaseState = new ChaseState(this, _chaseSpeed)
    .AddTransition(waitTransition);
```

3. **Construct State Machine** - Create the state machine, add your states, and initialize the machine:

```cs
_stateMachine = new StateMachine()
    .AddState(patrolState)
    .AddState(chaseState)
    .Initialize(patrolState);
```

## Usage
Use the example states and transitions, or create your own by basing your transitions on `ATransition` and states on `AState`, then add them to the state machine.

## Contributing
State Machine for Unity is an open-source project. Feel free to contribute by reporting issues, suggesting features, or opening pull requests.

## License
This project is licensed under the terms of the MIT license.

