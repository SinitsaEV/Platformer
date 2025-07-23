public interface IStateChanger
{
    void ChangeState<TNextState>() where TNextState : IState;
}
