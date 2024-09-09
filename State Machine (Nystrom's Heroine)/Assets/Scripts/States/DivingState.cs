using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        _characterController.rb.velocity = Vector3.down * _characterController.diveSpeed;
    }

    public void Exit(CharacterStateController characterController) { return; }

}
