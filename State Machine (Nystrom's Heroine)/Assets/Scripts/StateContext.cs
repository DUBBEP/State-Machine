using UnityEngine;

public class StateContext
{
    public IState CurrentState
    {
        get; set;
    }

    private readonly CharacterController _characterController;

    public StateContext (CharacterController characterController)
    {
        _characterController = characterController;
    }

    public void Transition()
    {
        CurrentState.Handle(_characterController);
    }

    public void Transition(IState state)
    {
        CurrentState = state;
        CurrentState.Handle(_characterController);
    }
}
