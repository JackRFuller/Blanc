using UnityEngine;
using System.Collections;

public class PlayerEventTrigger : MonoBehaviour {

	[SerializeField] private GameManager GM_Script;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter(Collider cc_Hit)
	{
		if(cc_Hit.tag == "Event Trigger")
		{
			DetermineEvent();
			cc_Hit.isTrigger = false;
			cc_Hit.enabled = false;
		}
	}

	void DetermineEvent()
	{
		switch(GM_Script.CurrentLevelState)
		{
			case (GameManager.LevelState.Building1):
			GM_Script.E1M_Script.TriggerEventStage();
			break;
		}
	}
}
