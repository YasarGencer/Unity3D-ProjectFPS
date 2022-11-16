using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    public int waypointIndex;
    public float waitTimer = 0;
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
            waitTimer += Time.deltaTime;
            if(waitTimer > 3){
                if(waypointIndex < enemy.path.waypoints.Count - 1){
                    waypointIndex++;
                }
                else {
                    waypointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
                waitTimer=0;
            }
        }
        Debug.Log("REMAINING DIST = " + enemy.Agent.remainingDistance);
        Debug.Log("TARGET POS = " + enemy.path.waypoints[waypointIndex].position);
    }
}
