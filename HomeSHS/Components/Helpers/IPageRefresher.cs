namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}
