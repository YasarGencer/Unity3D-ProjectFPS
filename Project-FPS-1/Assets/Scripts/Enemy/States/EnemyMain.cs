using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMain : MonoBehaviour
{
    private EnemyStateManager _stateManager;
    private NavMeshAgent _agent;
    public NavMeshAgent Agent { get => _agent;}
    
    [SerializeField] private string _currentState;

    public EnemyPath Path;
    
    private void Awake() {
        _stateManager = GetComponent<EnemyStateManager>();
        _agent = GetComponent<NavMeshAgent>();
        _stateManager.Init();
    }
}
