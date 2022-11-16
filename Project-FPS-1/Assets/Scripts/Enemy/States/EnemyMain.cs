using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMain : MonoBehaviour
{
    private EnemyStateManager stateManager;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent;}
    
    [SerializeField] private string currentState;

    public EnemyPath path;
    
    private void Awake() {
        stateManager = GetComponent<EnemyStateManager>();
        agent = GetComponent<NavMeshAgent>();
        stateManager.Init();
    }
}
