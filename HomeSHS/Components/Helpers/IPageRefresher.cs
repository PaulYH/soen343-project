﻿namespace HomeSHS.Components.Helpers
{
    public interface IPageRefresher
    {
        event Action IndexRefreshRequested;
        event Action SHSTabRefreshRequested;
        event Action SHCTabRefreshRequested;
        event Action SHHTabRefreshRequested;
        event Action SimulatorSettingsRefreshRequested;
        event Action SimulationInfoRefreshRequested;
        void CallIndexRequestRefresh();
        void CallSHSTabRefreshRequested();
        void CallSHCTabRefreshRequested();
        void CallSHHTabRefreshRequested();
        void CallSimulatorSettingsRefresh();
        void CallSimulationInfoRefresh();
    }
}
