using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The script for the guards
/// </summary>
public class StateMachine : MonoBehaviour
{
    //To control the movement for the guard over the navmesh
    public NavMeshAgent Agent;

    //To control the line of sight
    public LineOfSight LineOfSight;

    //The list of states that the guard can be in
    [SerializeField]
    private List<AStates> _stateBehaviours = new List<AStates>();

    //The default state that the guard will be in (the first state in the list)
    [SerializeField]
    private int _defaultState = 0;

    //The current state that the guard is in
    private AStates _currentState;

    /// <summary>
    /// Initializes each state
    /// </summary>
    /// <returns>A boolean indicating if the initialization has been a success</returns>
    private bool InitializeStates()
    {
        for (int i = 0; i < _stateBehaviours.Count; i++)
        {
            AStates state = _stateBehaviours[i];
            if (state && state.InitializeState())
            {
                state.AssociatedStateMachine = this;
                continue;
            }

            Debug.Log($"StateMachine On {gameObject.name} has failed to initalize the state {_stateBehaviours[i]?.GetType().Name}!");
            return false;
        }

        return true;
    }

    void Start()
    {
        if (!InitializeStates())
        {
            // Stop This class from executing
            this.enabled = false;
            return;
        }
        
        if (_stateBehaviours.Count > 0)
        {
            int firstStateIndex = _defaultState < _stateBehaviours.Count ? _defaultState : 0;

            _currentState = _stateBehaviours[firstStateIndex];
            _currentState.OnStateStart();
        }
        else
        {
            Debug.Log($"StateMachine On {gameObject.name} is has no state behaviours associated with it!");
        }
    }

    void Update()
    {
        _currentState.OnStateUpdate();

        int newState = _currentState.StateTransitionCondition();
        if (IsValidNewStateIndex(newState)) SetState(newState);
    }

    private bool IsCurrentState(AStates state)
    {
        return _currentState == state;
    }

    private void SetState(int index)
    {
        _currentState.OnStateEnd();
        _currentState = _stateBehaviours[index];
        _currentState.OnStateStart();
    }

    private bool IsValidNewStateIndex(int stateIndex)
    {
        return stateIndex < _stateBehaviours.Count && stateIndex >= 0;
    }

    private AStates GetCurrentState()
    {
        return _currentState;
    }
}
