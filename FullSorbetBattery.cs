using System.Collections;
using System.Linq;
using MSCLoader;
using HutongGames.PlayMaker;
using UnityEngine;

public class FullSorbetBattery : Mod
{
	public override string ID => "FullSorbetBattery";

	public override string Name => "FullSorbetBattery";

	public override string Author => "schplorg";

	public override string Version => "0.0.2";

	public override string Description => "Makes the Sorbet battery never go empty";

	public override Game SupportedGames => Game.MyWinterCar;
    
    private void Awake()
    {
		ModConsole.Log("FullSorbetBattery loaded!");
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
