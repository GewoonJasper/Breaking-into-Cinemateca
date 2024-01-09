using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Transform))]
public class PatrolState : AStates
{
    public List<GameObject> PointOfInterests = new List<GameObject>();

    private int _target;

    [SerializeField] 
    private float _walkingSpeed = 1.0f;

    //animation values
    private float _initialSpeed;
    private float _targetSpeed;
    
    [SerializeField]
    private float _timeForTransition = 1.0f;
    private float _timer;

    private bool _hasTurned;


    public override bool InitializeState()
    {
        _targetSpeed = 0.5f;

        return true;;
    }

    public override void OnStateStart()
    {
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=green>Entering Patrol State</color>");
        
        SetTarget();

        AssociatedStateMachine.Agent.speed = 0;

        _initialSpeed = AssociatedStateMachine.GuardAnimator.GetFloat("MovementSpeed");
        _timer = 0.0f;

        _hasTurned = false;

        MoveToTarget();
    }

    public override void OnStateUpdate()
    {
        Animate();
    }

    public override void OnStateEnd()
    {
        AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", 0.5f);
        
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=green>Exiting Patrol State</color>");
    }

    public override int StateTransitionCondition()
    {
        bool seenPlayer = AssociatedStateMachine.LineOfSight.SeenObject();

        if (seenPlayer)
        {
            AssociatedStateMachine.GuardAnimator.Play("Pointing");
            AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", 1);

            AssociatedStateMachine.Audio.clip = AssociatedStateMachine.PlayerSeen;
            AssociatedStateMachine.Audio.Play();

            return (int) Config.States.Chase;
        }
        if (IsAtLocation()) return (int) Config.States.Idle;
        return (int) Config.States.Invalid;
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

    private void Animate()
    {
        if (_hasTurned)
        {
            _timer = Mathf.Clamp01(_timer + Time.deltaTime / _timeForTransition);
            AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", Mathf.Lerp(_initialSpeed, _targetSpeed, _timer));
            AssociatedStateMachine.Agent.speed = _walkingSpeed;
        }
        else
        {
            //Calculate the angle towards the target
            //If the target is behind the guard, change the RotationSpeed of the animator so that the guard turns towards the target (0.0f is left, 1.0f is right turn angle)
            //If the target is somewhere in front of the guard, he doesnt have to turn (0.5f)

            var targetLocation = PointOfInterests[_target].transform.position;
            var currentLocation = transform.position;

            var direction = targetLocation - currentLocation;

            var angle = Vector3.Angle(transform.forward, direction);

            //If angle is greater than 90 degrees, the target is behind the guard
            //And if is less than 270 degrees, the target is behind the guard

            if (angle < 90 && angle > 270)
            {
                _hasTurned = true;
            }
            else
            {
                float targetDirection;

                if (angle < 180) targetDirection = 1.0f; //turn right
                else targetDirection = 0.0f; //turn left

                _timer = Mathf.Clamp01(_timer + Time.deltaTime / (_timeForTransition * 2));
                AssociatedStateMachine.GuardAnimator.SetFloat("RotationSpeed", Mathf.Lerp(0.5f, targetDirection, _timer));
                //transform.rotation = AssociatedStateMachine.GuardAnimator.deltaRotation;

                if (_timer >= 1.0f)
                {
                    _timer = 0.0f;
                    _hasTurned = true;
                }
            }
        }
    }
}
