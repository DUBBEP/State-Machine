using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;
    }

    public void Exit() { return; }

    public void UpdateState()
    {
        if (Input.GetKey(KeyCode.S))
            _characterController.Duck();

        if (Input.GetKeyDown(KeyCode.Space))
            _characterController.Jump();
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Mathf.Abs(Input.GetAxis("Horizontal")) > 0 )
            _characterController.Move();

        Debug.Log("StandUpdate");
    }

    public void PhysicsUpdate() { return; }

}
