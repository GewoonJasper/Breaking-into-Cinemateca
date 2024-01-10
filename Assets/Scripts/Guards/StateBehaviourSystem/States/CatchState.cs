using UnityEngine;

public class CatchState : AStates
{
    public CaughtMenu CaughtMenu;

    public override bool InitializeState()
    {
        return CaughtMenu;
    }

    public override void OnStateStart()
    {
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=purple>Entering Catch State</color>");

        AssociatedStateMachine.Audio.clip = AssociatedStateMachine.PlayerCaught;
        AssociatedStateMachine.Audio.Play();
        
        //TODO Guard catch animation
        CaughtMenu.PlayerCaught();
    }

    public override void OnStateUpdate() {}

    public override void OnStateEnd()
    {
        if (AssociatedStateMachine.DebugOn)
            Debug.Log("<color=purple>Exiting Catch State</color>");
    }

    public override int StateTransitionCondition()
    {
        return (int) Config.States.Invalid;
    }
}
