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

    public void Exit(CharacterStateController characterController) { return; }

    void Update()
    {
        if (!_characterController)
            return;

        if (Input.GetKeyDown(KeyCode.S))
        {
            _characterController.Duck();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _characterController.Jump();
        }

        Debug.Log("StandUpdate");

    }
}
