
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace K13A.KDebug {
#if UDON
    public class ToggleWindow : UdonSharpBehaviour
    {
        public KDebug window;

        public override void Interact()
        {
            window.gameObject.SetActive(!window.gameObject.activeSelf);
            window.IsPause = !window.gameObject.activeSelf;
        }
    }

#else
    public class KDebug : MonoBehaviour
    {
        public bool PleaseImportUDON = false;
    }
#endif
}
