using System;

public class Coin : Item
{
    public int Value { get; private set; } = 10;

    public Action<Coin> Collected;

    public override void Accept(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}
