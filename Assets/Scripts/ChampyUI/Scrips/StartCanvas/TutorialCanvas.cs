using Assets.Library.ChampyUI.Scrips.Interfaces;
using UnityEngine;

namespace Assets.Library.ChampyUI.Scrips.StartCanvas
{
    public class TutorialCanvas : CanvasBase
    {
        void Update()
        {
            checkInput();
        }

        void checkInput()
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameStateManager.SetState(GameState.play);

            }
        }
    }
}