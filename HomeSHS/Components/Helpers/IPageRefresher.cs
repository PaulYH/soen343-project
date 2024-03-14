namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action IndexRefreshRequested;
        event Action SHCTabRefreshRequested;
        void CallIndexRequestRefresh();
        void CallSHCTabRefreshRequested();
    }
}
