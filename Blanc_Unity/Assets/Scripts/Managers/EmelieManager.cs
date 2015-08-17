using UnityEngine;
using System.Collections;

public class EmelieManager : MonoBehaviour {

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

    public Color StartColor;
    public Color EndColor;

    // Use this for initialization
    void Start () {

        CurrentLevelState = LevelState.Building1;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
