using System;
using System.Collections.Generic;

namespace Assets.Library.ChampyUI.Scrips.Interfaces
{
    [Serializable]
    public class GameStateMask
    {
        public List<GameState> gameStates = new List<GameState>();

        public bool GamesStateContains(GameState gameState)
        {
            return gameStates.Contains(gameState);
        }
    }
}