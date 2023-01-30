public interface IObserver
{
    //subject use this method to communicate with observers.
    public void OnNotify(BallActions ballActions);
}