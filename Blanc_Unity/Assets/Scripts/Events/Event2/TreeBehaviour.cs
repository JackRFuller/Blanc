using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

	[SerializeField] public Transform PC;
	[SerializeField] Renderer Tree_Mesh;
	[SerializeField] private Animation TreeGrowth;
	[SerializeField] private float DistanceToActivation;
	[SerializeField] private TreeBehaviour TB_Script;
	private bool FoundPC;
	private bool Event2;


	// Use this for initialization
	void Start () {

		PC = GameObject.Find("PC").transform;
		Tree_Mesh.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update () {


		DetectPC();
		
	
	}

	void DetectPC()
	{
		float DistanceToPC = Vector3.Distance(PC.position, transform.position);
		if(DistanceToPC <= DistanceToActivation)
		{
			ActivateAnimation();
		}
	}

	void ActivateAnimation()
	{
		TreeGrowth.Play("TreeGrowth");
		TB_Script.enabled = false;
	}
}
