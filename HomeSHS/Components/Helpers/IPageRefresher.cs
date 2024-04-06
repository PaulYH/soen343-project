namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action IndexRefreshRequested;
        event Action SHSTabRefreshRequested;
        event Action SHCTabRefreshRequested;
        event Action SHHTabRefreshRequested;
        event Action SHPTabRefreshRequested;
        event Action SelectedRoomSHHInfoRefreshRequested;
        event Action SelectedRoomSHPInfoRefreshRequested;
        event Action SimulatorSettingsRefreshRequested;
        event Action SimulationInfoRefreshRequested;
        event Action HomeRenderRefreshRequested;
        event Action OutputConsoleRefreshRequested;
        void CallIndexRequestRefresh();
        void CallSHSTabRefreshRequested();
        void CallSHCTabRefreshRequested();
        void CallSHHTabRefreshRequested();
        void CallSHPTabRefreshRequested();
        void CallSelectedRoomSHHInfoRefresh();
        void CallSelectedRoomSHPInfoRefresh();
        void CallSimulatorSettingsRefresh();
        void CallSimulationInfoRefresh();
        void CallHomeRenderRefresh();
        void CallOutputConsoleRefresh();
    }
}
