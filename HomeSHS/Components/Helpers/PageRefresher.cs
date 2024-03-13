namespace HomeSHS.Components.Helpers
{
    public class PageRefresher : IPageRefresher
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}
