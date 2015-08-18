using UnityEngine;
using System.Collections;

public class Event1Manager : MonoBehaviour {

	[SerializeField] private int EventStage = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void TriggerEventStage()
	{
		switch(EventStage)
		{
		case 0:
			Debug.Log("Success");
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		}
	}
}
