namespace HomeSHS.Components.Helpers
{
    public class PageRefresher : IPageRefresher
    {
        public event Action IndexRefreshRequested;
        public event Action SHCTabRefreshRequested;

        public void CallIndexRequestRefresh()
        {
            IndexRefreshRequested?.Invoke();
        }

        public void CallSHCTabRefreshRequested()
        {
            SHCTabRefreshRequested?.Invoke();
        }
    }
}
