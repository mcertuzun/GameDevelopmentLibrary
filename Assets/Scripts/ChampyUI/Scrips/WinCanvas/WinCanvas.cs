

namespace Assets.Library.ChampyUI.Scrips.WinCanvas
{
    using Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class WinCanvas : CanvasBase
    {

        public void Initialize()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
            GetComponent<Canvas>().planeDistance = 1;
        }

        public void NextLevel()
        {

        }


    }
}