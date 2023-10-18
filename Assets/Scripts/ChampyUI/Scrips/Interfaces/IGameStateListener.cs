using System;

namespace Assets.Library.ChampyUI.Scrips.Interfaces
{
    public interface IGameStateListener
    {
        void StartListen();
        void StopListen();
        void OnGameStateChange(GameState gameState);
    }
}