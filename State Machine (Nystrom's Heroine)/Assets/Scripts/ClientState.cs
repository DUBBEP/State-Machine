using UnityEngine;

public class ClientState : MonoBehaviour
{
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = (CharacterController)
                               FindObjectOfType(typeof(CharacterController));
    }

    // the following code will be the controls for our character
}
