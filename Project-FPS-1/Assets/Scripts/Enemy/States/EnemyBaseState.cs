public abstract class EnemyBaseState
{
    public EnemyMain enemy;
    public EnemyStateManager stateManager;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}
