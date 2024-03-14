namespace HomeSHS.Components.Helpers
{
    public class PageRefresher : IPageRefresher
    {
        public event Action IndexRefreshRequested;
        public event Action SHSTabRefreshRequested;
        public event Action SHCTabRefreshRequested;
        public event Action SimulatorSettingsRefreshRequested;

        public void CallIndexRequestRefresh()
        {
            IndexRefreshRequested?.Invoke();
        }
        public void CallSHSTabRefreshRequested()
        {
            SHSTabRefreshRequested?.Invoke();
        }

        public void CallSHCTabRefreshRequested()
        {
            SHCTabRefreshRequested?.Invoke();
        }

        public void CallSimulatorSettingsRefresh()
        {
            SimulatorSettingsRefreshRequested?.Invoke();
        }
    }
}
