using UnityEngine;

public class StateContext
{
    public IState CurrentState
    {
        get; set;
    }

    private readonly CharacterStateController _characterController;

    public StateContext (CharacterStateController characterController)
    {
        _characterController = characterController;
    }

    public void Transition()
    {
        CurrentState.Handle(_characterController);
    }

    public void Transition(IState state)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        
        CurrentState = state;
        CurrentState.Handle(_characterController);
    }

    public void HandleUpdate()
    {
        CurrentState.UpdateState();
    }

    public void HandlePhysics()
    {
        CurrentState.PhysicsUpdate();
    }
}
