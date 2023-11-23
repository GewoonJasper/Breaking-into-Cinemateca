using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class IdleState : AStates
{
    //The chance of changing state where 1 is 1% and 100 is 100%
    [SerializeField]
    [Range(1, 100)]
    private float _changeStateChance = 5;

    public override bool InitializeState()
    {
        return true;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=cyan>Entering Idle State</color>");
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateEnd()
    {
        Debug.Log("<color=cyan>Exiting Idle State</color>");
    }

    public override int StateTransitionCondition()
    {
        var number = Random.Range(1, 100);

        //TODO replace numbers with enum value
        if (number <= _changeStateChance) return 0;
        return -1;
    }
}
