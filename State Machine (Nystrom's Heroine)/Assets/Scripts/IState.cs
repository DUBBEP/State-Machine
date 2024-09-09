using UnityEngine;

public interface IState
{
    void Handle(CharacterStateController controller);
    void Exit(CharacterStateController controller);
}
