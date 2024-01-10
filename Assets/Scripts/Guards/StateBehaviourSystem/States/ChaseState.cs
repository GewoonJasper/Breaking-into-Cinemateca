using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class ChaseState : AStates
{
    public GameObject Player;
    private Vector3 _playerLocation;

    [SerializeField]
    private AmbienceTrigger _ambienceTrigger;

    [SerializeField]
    private AudioMixerSnapshot _chaseMusic;
    private AudioMixerSnapshot _oldAmbience;
    private bool _hasChangedAmbience = false;

    [SerializeField] 
    private float _runningSpeed = 1.0f;

    //animation values
    private float _initialSpeed;
    private float _targetSpeed = 1.0f;

    [SerializeField]
    private float _timeForTransition = 1.0f;
    private float _timer;

    public override bool InitializeState()
    {
        return Player;
    }

    public override void OnStateStart()
    {
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=yellow>Entering Chase State</color>");
        
        _playerLocation = Player.transform.position;

        AssociatedStateMachine.Agent.speed = 0;

        _timer = 0.0f;

        _initialSpeed = AssociatedStateMachine.GuardAnimator.GetFloat("MovementSpeed");

        _oldAmbience = _ambienceTrigger.Ambience;
        _ambienceTrigger.Ambience = _chaseMusic;
    }

    public override void OnStateUpdate()
    {
        if (!AssociatedStateMachine.GuardAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pointing"))
        {
            if (!_hasChangedAmbience)
            {
                _ambienceTrigger.ChangeAmbience();
                _hasChangedAmbience = true;
            }

            _timer = Mathf.Clamp01(_timer + Time.deltaTime / _timeForTransition);
            AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", Mathf.Lerp(_initialSpeed, _targetSpeed, _timer));

            AssociatedStateMachine.Agent.speed = _runningSpeed;
            // update the player location if the player is still in the field of view
            bool seenPlayer = AssociatedStateMachine.LineOfSight.SeenObject();
            if (seenPlayer)
            {
                _playerLocation = Player.transform.position;

                AssociatedStateMachine.Agent.SetDestination(_playerLocation);
            }
        }
    }

    public override void OnStateEnd()
    {
        AssociatedStateMachine.GuardAnimator.SetFloat("MovementSpeed", 1);
        
        _ambienceTrigger.Ambience = _oldAmbience;
        _ambienceTrigger.ChangeAmbience();
        
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=yellow>Exiting Chase State</color>");
    }

    public override int StateTransitionCondition()
    {
        if (Vector3.Distance(transform.position, _playerLocation) < 2) return (int) Config.States.Catch;
        if (IsAtLocation()) return (int) Config.States.Patrol;
        return (int) Config.States.Invalid;
    }

    private bool IsAtLocation()
    {
        var targetLocation = _playerLocation;
        var currentLocation = transform.position;

        return Vector3.Distance(targetLocation, currentLocation) < 0.5f;
    }
}
