namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action IndexRefreshRequested;
        event Action SHCTabRefreshRequested;
        event Action SimulatorSettingsRefreshRequested;
        void CallIndexRequestRefresh();
        void CallSHCTabRefreshRequested();
        void CallSimulatorSettingsRefresh();
    }
}
