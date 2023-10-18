using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Library.ChampyUI.Scrips.Interfaces;

namespace Assets.Library.ChampyUI.Scrips
{
    public class FailCanvas : CanvasBase
    {
        bool levelFinalizeCompleted;
        public void UpdateLevelAndPoints()
        {
            levelFinalizeCompleted = true;
        }
        public void Retry()
        {

        }

    }
}