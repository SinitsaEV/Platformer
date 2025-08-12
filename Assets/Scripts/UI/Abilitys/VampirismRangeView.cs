using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Vampirism))]
public class VampirismRangeView : MonoBehaviour
{
    private Vampirism _vampirism;
    private Renderer _renderer;
    private Transform _transform;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _vampirism = GetComponent<Vampirism>();
        _transform = GetComponent<Transform>();
        OnVampirismDisabled();
    }

    private void OnEnable()
    {
        _vampirism.OnStarted += OnVampirismEnabled;
        _vampirism.OnEnded += OnVampirismDisabled;
    }

    private void OnDisable()
    {
        _vampirism.OnStarted -= OnVampirismEnabled;
        _vampirism.OnEnded -= OnVampirismDisabled;
    }

    private void OnVampirismEnabled()
    {
        float scale = _vampirism.Range;
        _transform.localScale = new Vector2(scale, scale);
        _renderer.enabled = true;
    }

    private void OnVampirismDisabled()
    {
        _renderer.enabled = false;
    }
}
