using UnityEngine;
using System.Collections;

public class Event2Manager : MonoBehaviour {

	[SerializeField] private E_WaypointBehaviour EWB_Script;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void BeginWaypointFollow()
	{
		EWB_Script.WaypointsActive = true;
	}
}
