
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
namespace K13A.KDebug
{
#if UDON

    public class TestLogger : UdonSharpBehaviour
    {
        public KDebug Debug;

        public bool isNormal = true;
        public bool isWarnning = false;
        public bool isError = false;

        public string LogMassage = "Here...";

        public override void Interact()
        {
            if (isNormal)
            {
                Debug.Log(this, LogMassage);

                for (var i = 0; i < 10; i++)
                {
                    Debug.Log(this, i.ToString());
                }
            }
            if (isWarnning)
            {
                Debug.LogWarn(this, LogMassage);

                for (var i = 0; i < 10; i++)
                {
                    Debug.LogWarn(this, i.ToString());
                }
            }
            if (isError)
            {
                Debug.LogError(this, LogMassage);

                for (var i = 0; i < 10; i++)
                {
                    Debug.LogError(this, i.ToString());
                }
            }
        }

        private void Start()
        {
            Debug.Log(this, "Tester Ready.");
        }
    }

#else
    public class TestLogger : MonoBehaviour
    {
        public bool PleaseImportUDON = false;
    }
#endif
}
