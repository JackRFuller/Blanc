using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

	public enum ActiveCharacter
	{
		PC,
		E
	}

	public ActiveCharacter CurrentCharacter;

	[SerializeField] private Animator[] AttachedPlatforms;
	private bool Activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(!Activated)		
		{
			if(CurrentCharacter == ActiveCharacter.PC)
			{
				if(collider.tag == "Player")
				{
					ActivateAnimations();
				}
			}
		}

	}

	void ActivateAnimations()
	{
		foreach(Animator animator in AttachedPlatforms)
		{
			animator.enabled = true;
		}
		Activated = true;
	}
}
