using UnityEngine;
using System.Collections;

public class E_WaypointBehaviour : MonoBehaviour {

	public bool WaypointsActive = false;
	public int CurrentWaypointManager = 0;

	[Header("Character Movement Attributes")]
	[SerializeField] private CharacterController Controller;
	[SerializeField] private float Speed;
	[SerializeField] private float TurnSpeed;
	[SerializeField] private float Gravity;
	private Vector3 moveDirection = Vector3.zero;

	[System.Serializable]
	public class WaypointAttributes
	{
		public int CurrentWaypoint;
		public Transform[] WaypointPos;
		public bool Loop;
		public bool Slerp;
	}

	[Header("Waypoint Manager")]
	public WaypointAttributes[] Waypoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(WaypointsActive)
		{
			if(Waypoints[CurrentWaypointManager].Slerp)
			{

			}
			else
			{
				FollowPath();
			}
		}
	
	}

	#region FollowPath Slerp

	void FollowPath_Slerp()
	{
		if(Waypoints[CurrentWaypointManager].CurrentWaypoint < Waypoints[CurrentWaypointManager].WaypointPos.Length)
		{
			if(Controller.isGrounded)
			{
				Vector3 Target_Waypoint = Waypoints[CurrentWaypointManager].WaypointPos[Waypoints[CurrentWaypointManager].CurrentWaypoint].position;

				Target_Waypoint.y = transform.position.y;

				moveDirection = Target_Waypoint - transform.position;

				if(moveDirection.magnitude < 0.1F)
				{
					transform.position = Target_Waypoint;
					Waypoints[CurrentWaypointManager].CurrentWaypoint++;
				}
				else
				{
					Quaternion Rotation = Quaternion.LookRotation(moveDirection);
					transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * TurnSpeed);
					Controller.Move(moveDirection.normalized * Speed * Time.deltaTime);
				}
			}
			moveDirection.y -= Gravity * Time.deltaTime;

			Controller.Move(moveDirection.normalized * Speed * Time.deltaTime);
		}
		else
		{
			if(Waypoints[CurrentWaypointManager].Loop)
			{
				Waypoints[CurrentWaypointManager].CurrentWaypoint = 0;
			}
		}
	}

	#endregion

	#region StandardWaypoints

	void FollowPath()
	{
		if(Waypoints[CurrentWaypointManager].CurrentWaypoint < Waypoints[CurrentWaypointManager].WaypointPos.Length)
		{
			if(Controller.isGrounded)
			{
				Vector3 Target_Waypoint = Waypoints[CurrentWaypointManager].WaypointPos[Waypoints[CurrentWaypointManager].CurrentWaypoint].position;

				Target_Waypoint.y = transform.position.y;

				moveDirection = Target_Waypoint - transform.position;

				if(moveDirection.magnitude < 0.1f)
				{
					transform.position = Target_Waypoint;
					Waypoints[CurrentWaypointManager].CurrentWaypoint++;
				}
				else
				{
					transform.LookAt(Target_Waypoint);
					Controller.SimpleMove(moveDirection.normalized * Speed * Time.deltaTime);
				}

			}
			moveDirection.y -= Gravity * Time.deltaTime;

			Controller.Move(moveDirection.normalized * Speed * Time.deltaTime);
		}
		else
		{
			if(Waypoints[CurrentWaypointManager].Loop)
			{
				Waypoints[CurrentWaypointManager].CurrentWaypoint = 0;
			}
		}
	}

	#endregion
}
