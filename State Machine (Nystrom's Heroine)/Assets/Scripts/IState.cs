using UnityEngine;

public interface IState
{
    void Handle(CharacterController controller);
}
