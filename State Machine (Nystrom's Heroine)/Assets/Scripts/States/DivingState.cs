using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingState : BaseAirState, IState
{
    private CharacterStateController _characterController;

    public void Handle(CharacterStateController characterController)
    {
        if (!_characterController)
            _characterController = characterController;
        
        _characterController.rb.velocity = new Vector3(_characterController.rb.velocity.x, 0, _characterController.rb.velocity.z);
        _characterController.rb.AddForce(Vector3.down * _characterController.diveSpeed, ForceMode.Impulse);
    }

    public void Exit() { return; }


    public void UpdateState()
    {
        if (!_characterController)
            return;

        // checks for the ground and input for bounce state
        BasicAirStateChecks(_characterController);

        Debug.Log("DiveUpdate");
    }

    public void PhysicsUpdate() { return; }

}
