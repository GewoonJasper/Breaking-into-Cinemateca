using UnityEngine;

public class CatchState : AStates
{
    public GameObject Player;
    public CaughtMenu CaughtMenu;

    public override bool InitializeState()
    {
        return Player;
    }

    public override void OnStateStart()
    {
        Debug.Log("<color=purple>Entering Catch State</color>");
        //TODO Guard catch animation
        CaughtMenu.PlayerCaught();
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
