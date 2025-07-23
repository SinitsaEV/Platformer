public interface IStateMachine: IStateChanger
{
    void Run();
    void Update();
    void Stop();
}
