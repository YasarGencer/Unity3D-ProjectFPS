using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public EnemyBaseState activeState;

    //STATES
    public EnemyPatrolState patrolState;

    public void Init(){
        patrolState = new EnemyPatrolState();
        ChangeState(patrolState);
    }
    private void Update() {
        if(activeState != null){
            activeState.Perform();
        }
    }
    public void ChangeState(EnemyBaseState nextState){
        if(activeState != null){
            activeState.Exit();
        }
        activeState = nextState;
        if(activeState != null){
            activeState.stateManager = this;
            activeState.enemy = GetComponent<EnemyMain>();
            activeState.Enter();
        }
    }
}
