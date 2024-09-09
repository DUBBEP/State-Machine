using UnityEngine;

public interface IState
{
    void Handle(CharacterStateController controller);
    void Exit();
    void UpdateState();

}
