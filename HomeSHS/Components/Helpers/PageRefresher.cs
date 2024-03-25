namespace HomeSHS.Components.Helpers
{
    public class PageRefresher : IPageRefresher
    {
        public event Action IndexRefreshRequested;
        public event Action SHSTabRefreshRequested;
        public event Action SHCTabRefreshRequested;
        public event Action SHHTabRefreshRequested;
        public event Action SelectedRoomSHHInfoRefreshRequested;
        public event Action SimulatorSettingsRefreshRequested;
        public event Action SimulationInfoRefreshRequested;

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

        public void CallSHHTabRefreshRequested()
        {
            SHHTabRefreshRequested?.Invoke();
        }

        public void CallSelectedRoomSHHInfoRefresh()
        {
            SelectedRoomSHHInfoRefreshRequested?.Invoke();
        }
        public void CallSimulatorSettingsRefresh()
        {
            SimulatorSettingsRefreshRequested?.Invoke();
        }

        public void CallSimulationInfoRefresh()
        {
            SimulationInfoRefreshRequested?.Invoke();
        }
    }
}
