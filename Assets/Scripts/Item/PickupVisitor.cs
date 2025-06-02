public class PickupVisitor: IPickupVisitor
{
    private Player _player;

    public PickupVisitor(Player player)
    {
        _player = player;
    }

    public void Visit(Coin coin)
    {
        Wallet wallet = _player.GetComponent<Wallet>();

        if(wallet != null )
        {
            wallet.AddCoin(coin);
            coin.Collected?.Invoke(coin);
        }
    }
}
