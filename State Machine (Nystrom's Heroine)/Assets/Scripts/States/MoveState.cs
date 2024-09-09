using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;
    public void Exit() { return; }
    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;
    }
    public void UpdateState()
    {
        if (!_characterController)
            return;

        float xInput = Input.GetAxis("Horizontal");

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Mathf.Abs(xInput) <= 1)
            _characterController.Stand();
        else
            _characterController.rb.velocity = new Vector3(xInput * _characterController.walkSpeed,
                                                            _characterController.rb.velocity.y,
                                                            _characterController.rb.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
            _characterController.Jump();
    }
}
