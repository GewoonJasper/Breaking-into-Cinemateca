using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AStates
{
    [SerializeField]
    private string _playerTagName = "";

    private GameObject _player;
    private Transform _playerLocation;
    private Vector3 _lastPlayerLocation;

    public override bool InitializeState()
    {
        _player = GameObject.Find(_playerTagName);

        return _player;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=yellow>Entering Chase State</color>");
        _playerLocation = _player.transform;
    }

    public override void OnStateUpdate()
    {
        // update the player location if the player is still in the field of view
        bool seenPlayer = AssociatedStateMachine.LineOfSight.SeenObject();
        if (seenPlayer)
        {
            Debug.Log("Seen player");
            _playerLocation = _player.transform;
            _lastPlayerLocation = _playerLocation.position;

            AssociatedStateMachine.Agent.SetDestination(_playerLocation.position);
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
        if (_lastPlayerLocation == null)
            return false;

        var targetLocation = _lastPlayerLocation;
        var currentLocation = transform.position;

        return Vector3.Distance(targetLocation, currentLocation) < 0.1f;
    }
}
