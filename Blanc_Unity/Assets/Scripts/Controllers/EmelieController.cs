using UnityEngine;
using System.Collections;

public class EmelieController : EmelieManager {    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, Time.time);
	
	}
}
