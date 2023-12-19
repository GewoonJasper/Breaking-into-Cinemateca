using UnityEngine;

public class CatchState : AStates
{
    public GameObject Player;
    private Vector3 _playerStartLocation;

    public override bool InitializeState()
    {
        _playerStartLocation = Player.transform.position;
        return Player;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=purple>Entering Catch State</color>");
        //TODO Guard catch animation
        Player.transform.position = _playerStartLocation;
    }

    public override void OnStateUpdate() {}

    public override void OnStateEnd()
    {
        Debug.Log("<color=purple>Exiting Catch State</color>");
    }

    public override int StateTransitionCondition()
    {
        return (int) Config.States.Patrol;
    }
}
