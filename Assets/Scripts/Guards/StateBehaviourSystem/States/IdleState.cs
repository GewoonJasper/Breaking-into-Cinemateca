using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleState : AStates
{
    //The chance of changing state where 0 is 0% and 100 is 100%
    [SerializeField]
    [Range(0, 100)]
    private float _changeStateChance = 5;

    //animation values
    private float _initialSpeed;
    private float _targetSpeed;

    [SerializeField]
    private float _timeForTransition = 1.0f;
    private float _timer;

    //Special case for the hallway guard
    [SerializeField] 
    private bool _hallwayGuard = false;

    public override bool InitializeState()
    {
        _targetSpeed = 0.0f;

        return true;
    }

    public override void OnStateStart()
    {
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=cyan>Entering Idle State</color>");

        AssociatedStateMachine.Agent.speed = 0;

        _timer = 0.0f;

        _initialSpeed = AssociatedStateMachine.GuardAnimator.GetFloat("MovementSpeed");

        AssociatedStateMachine.GuardAnimator.SetFloat("RotationSpeed", 0.5f);
    }

    public override void OnStateUpdate()
    {
        _timer = Mathf.Clamp01(_timer + Time.deltaTime / _timeForTransition);
        AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", Mathf.Lerp(_initialSpeed, _targetSpeed, _timer));
    }

    public override void OnStateEnd()
    {
        AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", 0.0f);
        AssociatedStateMachine.GuardAnimator.SetFloat("RotationSpeed", 0.5f);
        
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=cyan>Exiting Idle State</color>");
    }

    public override int StateTransitionCondition()
    {
        bool seenPlayer = AssociatedStateMachine.LineOfSight.SeenObject();
        if (seenPlayer)
        {
            //If the guard is the hallway guard, go to the catch state instantly
            if (_hallwayGuard) return (int) Config.States.Catch;

            AssociatedStateMachine.GuardAnimator.Play("Pointing");

            AssociatedStateMachine.Audio.clip = AssociatedStateMachine.PlayerSeen;
            AssociatedStateMachine.Audio.Play();
            return (int) Config.States.Chase;
        }

        var number = Random.Range(1, 100);
        if (!_hallwayGuard && number <= _changeStateChance) return (int) Config.States.Patrol;
        return (int) Config.States.Invalid;
    }
}
