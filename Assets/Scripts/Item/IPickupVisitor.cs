public interface IPickupVisitor 
{
    public void Visit(Coin coin);
    public void Visit(HealthPotion healthPotion);
}
