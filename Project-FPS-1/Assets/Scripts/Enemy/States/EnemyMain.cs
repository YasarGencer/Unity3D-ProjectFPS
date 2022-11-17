using UnityEngine;
using UnityEngine.AI;

public class EnemyMain : MonoBehaviour
{
    private EnemyStateManager _stateManager;
    private NavMeshAgent _agent;
    public NavMeshAgent Agent { get => _agent;}

    private EnemyPath _path;
    public EnemyPath Path { get => _path;}

    [SerializeField] private string _currentState;
    
    private void Awake() {
        _stateManager = GetComponent<EnemyStateManager>();
        _agent = GetComponent<NavMeshAgent>();
        _stateManager.Init();
    }
}
