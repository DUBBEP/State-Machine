using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : BaseAirState, IState
{
    private CharacterStateController _characterController;
    private float groundCheckWait;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;

        _characterController.rb.velocity = new Vector3(_characterController.rb.velocity.x, 0, _characterController.rb.velocity.z);
        _characterController.rb.AddForce(Vector3.up * _characterController.jumpForce, ForceMode.Impulse);
        groundCheckWait = 0.05f;
    }

    public void Exit() { return; }

    public void UpdateState()
    {
        if (!_characterController)
            return;

        Debug.Log("JumpUpdate");

        float xInput = Input.GetAxis("Horizontal");
        _characterController.rb.velocity = new Vector3(xInput * _characterController.walkSpeed,
                                                _characterController.rb.velocity.y,
                                                _characterController.rb.velocity.z);

        if (Input.GetKeyDown(KeyCode.S))
            _characterController.Dive();

        if (groundCheckWait > 0)
            groundCheckWait -= Time.deltaTime;

        // checks for the ground and input for bounce state
        if (groundCheckWait <= 0)
            BasicAirStateChecks(_characterController);
    }

    public void PhysicsUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            _characterController.rb.AddForce(Vector3.down * _characterController.jumpingGravForce);
        else
            _characterController.Fall();

    }
}
