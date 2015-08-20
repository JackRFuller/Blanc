using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public int currentWaypoint = 0;
	public CharacterController controller;

	public Transform[] Waypoints;
	public bool loop;

	public float speed = 2;
	public float turnspeed = 10;
	public float gravity = 20;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		FollowWaypoints();
	
	}

	void FollowWaypoints()
	{
		if(currentWaypoint < Waypoints.Length)
		{
			if(controller.isGrounded)
			{
				Vector3 WaypointPos = Waypoints[currentWaypoint].position;
				WaypointPos.y = transform.position.y;
				moveDirection = WaypointPos - transform.position;

				if(moveDirection.magnitude < 0.1F)
				{
					transform.position = WaypointPos;
					currentWaypoint++;
				}
				else
				{
					transform.LookAt(WaypointPos);
					controller.SimpleMove(moveDirection.normalized * speed * Time.deltaTime);
				}
			}

			moveDirection.y -= gravity*Time.deltaTime;
			controller.SimpleMove(moveDirection.normalized * speed * Time.deltaTime);
		}
		else		
		{
			if(loop)
			{
				currentWaypoint = 0;
			}
		}
	}
}
