using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : MonoBehaviour, IState
{
    private CharacterStateController _characterController;
    private float groundCheckWait;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        _characterController.rb.AddForce(Vector3.up * _characterController.jumpForce, ForceMode.Impulse);
        groundCheckWait = 0.4f;
    }

    public void Exit(CharacterStateController characterController) { return; }

    void Update()
    {
        if (!_characterController)
            return;

        if (groundCheckWait > 0)
            groundCheckWait -= Time.deltaTime;

            if (groundCheckWait <= 0)
                CheckForGround();
    }

    void CheckForGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            _characterController.Stand();
        }
        Debug.Log("JumpUpdate");

    }
}
