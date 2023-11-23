using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PatrolState : AStates
{
    public List<GameObject> PointOfInterests = new List<GameObject>();

    private int _target;

    private Transform _transform;

    public override bool InitializeState()
    {
        _transform = GetComponent<Transform>();

        return true;;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=green>Entering Patrol State</color>");
        SetTarget();
    }

    public override void OnStateUpdate()
    {
        MoveToTarget();
    }

    public override void OnStateEnd()
    {
        Debug.Log("<color=green>Exiting Patrol State</color>");
    }

    public override int StateTransitionCondition()
    {
        //TODO replace numbers with enum value
        if (IsAtLocation()) return 1;
        return -1;
    }

    private void MoveToTarget()
    {
        var targetLocation = PointOfInterests[_target].transform.position;

        AssociatedStateMachine.Agent.SetDestination(targetLocation);
    }

    private void SetTarget()
    {
        _target = Random.Range(0, PointOfInterests.Count);

        //Make sure the target is not the same as the current location,
        //unless there is only one location
        if (PointOfInterests.Count > 1 && IsAtLocation()) SetTarget();
    }

    private bool IsAtLocation()
    {
        var targetLocation = PointOfInterests[_target].transform.position;
        var currentLocation = transform.position;

        return Vector3.Distance(targetLocation, currentLocation) < 0.1f;
    }

}
