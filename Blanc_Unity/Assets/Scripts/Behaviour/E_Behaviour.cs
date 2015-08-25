using UnityEngine;
using System.Collections;

public class E_Behaviour : MonoBehaviour {

    [SerializeField] private GameManager GM_Script;
	[SerializeField] private Rigidbody E_RB;

    [Header("Building 1")]
    [SerializeField] private Renderer E_Mesh;
    [SerializeField] private Color StartColor;
    [SerializeField] private Color EndColor;
    [SerializeField] private float LerpTime;

	[Header("Raising Up")]
	[SerializeField] private Animation E_Animations;

	[Header("Building 2")]
	[SerializeField] private Event2Manager E2_Script;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {


	}

    public IEnumerator WakeUp()
    {
        GM_Script.CurrentLevelState = GameManager.LevelState.Building2;
        while(E_Mesh.material.color != EndColor)
        {
            E_Mesh.material.color = Color.Lerp(E_Mesh.material.color, EndColor, LerpTime * Time.deltaTime);
        }
        
        Debug.Log("A");       
        yield return new WaitForSeconds(LerpTime);

		StartCoroutine(LiftUp());
    }

	IEnumerator LiftUp()
	{
		E_RB.useGravity = false;
		E_Animations.Play("RaiseUp");
		yield return new WaitForSeconds(E_Animations.GetClip("RaiseUp").length);
		BeginEvent2();

	}

	void BeginEvent2()
	{
		E2_Script.BeginWaypointFollow();
	}


}
