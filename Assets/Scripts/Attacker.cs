using System.Collections;
using UnityEngine;

public class Attacker :MonoBehaviour, IAttacker
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _delay = 2f;
    private WaitForSeconds _attackDelay;

    public bool CanAttack {  get; private set; } = true;

    private void Awake()
    {
        _attackDelay = new WaitForSeconds(_delay);
    }

    public void Attack(IDamageable damageable)
    {
        if (CanAttack)
        {
            StartCoroutine(WaitBeforeNextAttack());
            damageable.TakeDamage(_damage);
        }
    }

    private IEnumerator WaitBeforeNextAttack()
    {
        CanAttack = false;
        yield return _attackDelay;
        CanAttack = true;
    }
}
