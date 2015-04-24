using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	public float speed = 3.0f;
	public float lifeTime = 4.0f;

	private float spawnTime;
	private Rigidbody rb;
	private GameObject player;

	void Start () {
		spawnTime = Time.time;

		// Set the trajectory of the projectile to mouse position
		rb = GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		// Prevent the projectile from rotating and messing up the collider
		rb.freezeRotation = true;

		// Get the distance between the mouse and the player,
		// then normalize because we use it to determine projectile trajectory

		// Need to find camera so as to convert viewport space to world space
		// That allows us to find position of the mouse wrt to the player in the world space
		Camera camera = Camera.main;

		// Get the mouse position, then convert to world space
		Vector3 mousePosition = camera.ViewportToWorldPoint (Input.mousePosition);

		Vector3 distance = mousePosition - player.transform.position;
		distance.Normalize ();
		rb.velocity = new Vector3 (distance.x, distance.y, 0) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - spawnTime) > lifeTime) {
			// TODO: Add a fading animation
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		// Makes the light stick to the surface it lands on
		if (other.tag != "Player" && other.tag != "Projectile") {
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
		}
	}
}
