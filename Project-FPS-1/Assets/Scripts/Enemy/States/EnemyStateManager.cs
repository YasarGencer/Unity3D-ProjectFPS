using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState ActiveState;

    //STATES
    public EnemyPatrolState PatrolState;

    public void Init(){
        PatrolState = new EnemyPatrolState();
        ChangeState(PatrolState);
    }
    private void Update() {
        if(ActiveState != null){
            ActiveState.Perform();
        }
    }
    public void ChangeState(EnemyBaseState nextState){
        if(ActiveState != null){
            ActiveState.Exit();
        }
        ActiveState = nextState;
        if(ActiveState != null){
            ActiveState.stateManager = this;
            ActiveState.enemy = GetComponent<EnemyMain>();
            ActiveState.Enter();
        }
    }
}
