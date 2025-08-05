using UnityEngine;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private Sprite _sprite;

    private void OnEnable()
    {
        _vampirism.OnStarted += OnStarted;
        _vampirism.OnEnded += OnEnded;
    }

    private void OnDisable()
    {
        _vampirism.OnStarted -= OnStarted;
        _vampirism.OnEnded -= OnEnded;
    }

    private void OnStarted()
    {
        Debug.Log("Start");
    }

    private void OnEnded()
    {
        Debug.Log("End");
    }
}
