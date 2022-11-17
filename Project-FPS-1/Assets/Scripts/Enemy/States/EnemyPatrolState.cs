using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    private int _waypointIndex;
    private float _waitTimer = 0;
    public override void Enter(){
        Debug.Log("PATROL START");
    }
    public override void Perform(){
        Debug.Log("PATROL PERFORM");
        PatrolCycle();
    }
    public override void Exit(){
        Debug.Log("PATROL END");
    }

    public void PatrolCycle(){
        if(enemy.Agent.remainingDistance < 0.2f){
            _waitTimer += Time.deltaTime;
            if(_waitTimer > 3){
                if(_waypointIndex < enemy.Path.Waypoints.Count - 1){
                    _waypointIndex++;
                }
                else {
                    _waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.Path.Waypoints[_waypointIndex].position);
                _waitTimer=0;
            }
        }
        Debug.Log("REMAINING DIST = " + enemy.Agent.remainingDistance);
        Debug.Log("TARGET POS = " + enemy.Path.Waypoints[_waypointIndex].position);
    }
}
