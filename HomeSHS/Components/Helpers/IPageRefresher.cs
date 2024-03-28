﻿namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action IndexRefreshRequested;
        event Action SHSTabRefreshRequested;
        event Action SHCTabRefreshRequested;
        event Action SHHTabRefreshRequested;
        event Action SelectedRoomSHHInfoRefreshRequested;
        event Action SimulatorSettingsRefreshRequested;
        event Action SimulationInfoRefreshRequested;
        event Action HomeRenderRefreshRequested;
        event Action OutputConsoleRefreshRequested;
        void CallIndexRequestRefresh();
        void CallSHSTabRefreshRequested();
        void CallSHCTabRefreshRequested();
        void CallSHHTabRefreshRequested();
        void CallSelectedRoomSHHInfoRefresh();
        void CallSimulatorSettingsRefresh();
        void CallSimulationInfoRefresh();
        void CallHomeRenderRefresh();
        void CallOutputConsoleRefresh();
    }
}
