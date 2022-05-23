using System;
using BepInEx;
using Nick;
using System.Collections;
using UnityEngine;
using System.Linq;
using BepInEx.Logging;

namespace UnlockEverything
{
    [BepInPlugin("com.steven.nasb.unlockeverything", "Unlock Everything", "1.0.0")]
    public class UnlockEverythingPlugin : BaseUnityPlugin
    {
        void Awake()
        {
            StartCoroutine(TriggerUnlockEverything());
        }

        IEnumerator TriggerUnlockEverything()
        {
            UnlockCheats uc = null;

            yield return new WaitUntil(() => uc = Resources.FindObjectsOfTypeAll<UnlockCheats>().FirstOrDefault());

            uc.InvokeMethod("UnlockEverything");

            Logger.Log(LogLevel.Info, "Unlocked everything!");
        }
    }
}
