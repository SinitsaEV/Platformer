using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if(collision.TryGetComponent<Item>(out Item item))
        {
            item.Accept(new PickupVisitor(_player));
        }
    }
}