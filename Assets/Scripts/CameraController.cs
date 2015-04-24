using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Vector3 offset;
	private GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		transform.position = player.transform.position + offset;
	}
}
