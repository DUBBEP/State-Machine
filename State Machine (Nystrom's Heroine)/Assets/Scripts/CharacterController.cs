using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // character variables below



    private IState
       _idleState, _jumpState, _diveState, _duckState;

    private StateContext _stateContext;

    private void Start()
    {
        _stateContext = new StateContext(this);

        /* set the state variables to new componets eg.
         * 
         * _idleState =
         *      gameObject.AddComponent<IdleState>();
         */

        _stateContext.Transition(_idleState);
    }

    public void Jump()
    {
        _stateContext.Transition(_jumpState);
    }
    public void Duck()
    {
        _stateContext.Transition(_duckState);
    }
    public void Dive()
    {
        _stateContext.Transition(_diveState);
    }

}
