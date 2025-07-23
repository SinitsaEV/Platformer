public class HealthPotion : Item
{
    public int HealthPoints { get; private set; } = 15;

    public override void Accept(IPickupVisitor visitor)
    {
        visitor.Visit(this);
    }
}
