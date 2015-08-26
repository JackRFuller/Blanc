using UnityEngine;
using System.Collections;

public class PlayerEventTrigger : MonoBehaviour {

	[SerializeField] private GameManager GM_Script;

	[SerializeField] private Event1Manager E1M_Script;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Event Trigger")
		{
			DetermineEvent();
			collider.enabled = false;
		}
	}

	void DetermineEvent()
	{
		switch(GM_Script.CurrentLevelState)
		{
			case(GameManager.LevelState.Building1):
			E1M_Script.EventTrigger();
			break;
		}
	}
}
