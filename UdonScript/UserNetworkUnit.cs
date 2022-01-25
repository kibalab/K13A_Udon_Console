
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace K13A.KDebug
{
#if UDON
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class UserNetworkUnit : UdonSharpBehaviour
    {
        [UdonSynced, HideInInspector, FieldChangeCallback(nameof(NetworkLog))] public string m_NetworkLog = "";
        public KDebug Debug;
        [UdonSynced, HideInInspector, FieldChangeCallback(nameof(UserID))] public int OwnerID = -1;
        public string ColorCode = "";

        public string receivedLog = "";

        private char[] hex = { '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', };

        public string NetworkLog
        {
            set
            {
                receivedLog += Debug.CutLogs(value, Debug.AllowStringCount - 500);

                Debug.m_NetworkLog(value);
                m_NetworkLog = value;
            }

            get => m_NetworkLog;
        }

        public string SendLog
        {
            set
            {
                m_NetworkLog = value;
                receivedLog += Debug.CutLogs(value, Debug.AllowStringCount - 500);
                Debug.AllLogs += Debug.CutLogs(value, Debug.AllowStringCount - 500);
            }
        }

        public int UserID
        {
            set
            {
                OwnerID = value;

                var player = VRCPlayerApi.GetPlayerById(value);

                if(player == null)
                {
                    Debug.LogError(this, $"Debug Network Unit is broken");
                }

                Debug.Log(this, $"Debug Network Unit is ready");

                Debug.FilterDropDown.AddItem($"{player.displayName}.{player.playerId}", this);
            }
        }

        public void TrySync()
        {
            RequestSerialization();
        }

        public void SetOwner()
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            OwnerID = Networking.LocalPlayer.playerId;
            RequestSerialization();
        }

        public void init()
        {
            ColorCode = $"#{hex[Random.Range(0, 7)]}{hex[Random.Range(0, 7)]}{hex[Random.Range(0, 7)]}{hex[Random.Range(0, 7)]}{hex[Random.Range(0, 7)]}{hex[Random.Range(0, 7)]}";

            
        }

        public void ClearLog()
        {
            receivedLog = "";
        }
    }

#else
    public class TestLogger : MonoBehaviour
    {
        public bool PleaseImportUDON = false;
    }
#endif
}