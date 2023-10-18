using Assets.Library.ChampyUI.Scrips.Interfaces;
using UnityEngine;

namespace Assets.Library.ChampyUI.Scrips
{
    public class UIMain : MonoBehaviour
    {
        //TODO  Move the UI selections to a scriptablebin
        public static UIMain instance;
        [HideInInspector] public bool DebugMode;
        [HideInInspector] public bool VideoMode;


        void Start()
        {
            var listeners = GetComponentsInChildren<IGameStateListener>(true);
            for (int i = 0; i < listeners.Length; i++)
            {
                listeners[i].StartListen();
            }
        }

        private void Awake()
        {
            instance = this;
        }
    }
}