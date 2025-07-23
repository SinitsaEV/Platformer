public abstract class EnemyState : IState
{
    protected IStateChanger _changer;

    protected EnemyState(IStateChanger changer)
    {
        _changer = changer;
    }

    public virtual void Enter() { }    

    public virtual void Exit() { }

    public virtual void Update() { }    
}
