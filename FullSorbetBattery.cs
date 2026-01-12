using System.Collections;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using HutongGames.PlayMaker;
using UnityEngine;

[BepInPlugin("de.schplorg.fullsorbetbattery", "Full Sorbet Battery", "0.0.1")]
public class FullSorbetBattery : BaseUnityPlugin
{
    private void Awake()
    {
    }

    private void Update()
    {
        GameObject sorbetGo = GameObject.Find("SORBET(190-200psi)");
        if(sorbetGo) {
            var electricity = sorbetGo.GetComponentsInChildren<PlayMakerFSM>().ToList().Find(fsm => fsm.FsmName == "Power");
            if (electricity)
            {
                var charge = electricity.FsmVariables.FindFsmFloat("Charge");
                charge.Value = Mathf.Max(charge.Value, 90f);
            }
        }
    }
}
