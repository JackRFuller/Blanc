using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	#region Enums

	public enum LevelState
	{
		Building1,
		Building2,
		Building3,
		Building4,
		Building5A,
		Building5B,
		Building6,
		Building7,
		Building8,
		Building9,
	}
	
	public LevelState CurrentLevelState;
	
	#endregion

	#region Event Managers

	public Event1Manager E1M_Script;

	#endregion

	[SerializeField] PlayerEventTrigger PET_Script;

	// Use this for initialization
	void Start () {

		CurrentLevelState = LevelState.Building1;

	}

}
	

