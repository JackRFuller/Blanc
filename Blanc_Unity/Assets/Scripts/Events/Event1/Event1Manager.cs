using UnityEngine;
using System.Collections;

public class Event1Manager : MonoBehaviour {

	[SerializeField] private int EventStage = 0;

	[Header("Text Pillars")]
	[SerializeField] private Animator[] TextPillars;
	private int TextPillarID = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EventTrigger()
	{
		switch(EventStage)
		{
		case 0:
			RaiseSinglePillar();
			break;
		}
	}

	void RaiseSinglePillar()
	{
		TextPillars[TextPillarID].enabled = true;
		TextPillarID++;
	}
}
