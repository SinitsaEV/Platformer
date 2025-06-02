using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void Accept(IPickupVisitor visitor);
}
