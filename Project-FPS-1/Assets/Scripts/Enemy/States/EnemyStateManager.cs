using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private EnemyBaseState _activeState;

    //STATES
    private EnemyPatrolState _patrolState;

    public void Init(){
        _patrolState = new EnemyPatrolState();
        ChangeState(_patrolState);
    }
    private void Update() {
        if(_activeState != null){
            _activeState.Perform();
        }
    }
    public void ChangeState(EnemyBaseState nextState){
        if(_activeState != null){
            _activeState.Exit();
        }
        _activeState = nextState;
        if(_activeState != null){
            _activeState.stateManager = this;
            _activeState.enemy = GetComponent<EnemyMain>();
            _activeState.Enter();
        }
    }
}