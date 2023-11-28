using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AStates
{
    [SerializeField]
    private string _playerTagName = "";

    private GameObject _player;
    private Vector3 _playerLocation;

    public override bool InitializeState()
    {
        _player = GameObject.Find(_playerTagName);

        return _player;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=yellow>Entering Chase State</color>");
        _playerLocation = _player.transform.position;
    }

    public override void OnStateUpdate()
    {
        // update the player location if the player is still in the field of view
        bool seenPlayer = AssociatedStateMachine.LineOfSight.SeenObject();
        if (seenPlayer)
        {
            _playerLocation = _player.transform.position;

            AssociatedStateMachine.Agent.SetDestination(_playerLocation);
        }
    }

    public override void OnStateEnd()
    {
        Debug.Log("<color=yellow>Exiting Chase State</color>");
    }

    public override int StateTransitionCondition()
    {
        if (IsAtLocation()) return (int) Config.States.Patrol;
        return (int) Config.States.Invalid;
    }

    private bool IsAtLocation()
    {
        var targetLocation = _playerLocation;
        var currentLocation = transform.position;

        return Vector3.Distance(targetLocation, currentLocation) < 0.1f;
    }
}