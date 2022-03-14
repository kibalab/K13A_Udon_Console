﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace K13A.KDebug {
#if UDON
    public class ToggleWindow : UdonSharpBehaviour
    {
        public bool isActive = false;

        public KDebug window;

        private void Start()
        {
            if(!isActive) Interact();
        }

        public override void Interact()
        {
            window.gameObject.SetActive(!window.gameObject.activeSelf);
            window.IsPause = !window.gameObject.activeSelf;
        }

        private void Update()
        {
            for (var i = 0; i< 10; i++)
            {
                window.Log(this, i.ToString());
            }
        }
    }

#else
    public class KDebug : MonoBehaviour
    {
        public bool PleaseImportUDON = false;
    }
#endif
}
