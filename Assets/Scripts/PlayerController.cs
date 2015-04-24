using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float jumpSpeed = 2.5f;
	public float zOffset = -1.5f;
	public GameObject projectile;

	private Rigidbody rb; 
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Jump put in update to make it more responsive
		if (IsGrounded () && Input.GetButtonDown ("Jump")) {
			rb.velocity = new Vector3(
				rb.velocity.x, 
				jumpSpeed,
				0
				);
		}

		// Projectile code
		if (Input.GetMouseButtonDown (0)) {
			// Spawns a projectile starting at the player,
			// with an offset on the z-axis so that they can be seen
			Instantiate(
				projectile, 
				new Vector3(transform.position.x, transform.position.y, zOffset), 
				Quaternion.identity);
		}
	}
	
	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector3 (
			move * speed,
			rb.velocity.y,
			0.0f
			);
	}
	
	bool IsGrounded() {
		return Physics.Raycast(rb.position, -Vector3.up, 
		                         GetComponent<Collider>().bounds.extents.y + 0.1f);
	}
}
