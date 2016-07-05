using UnityEngine;
using System.Collections;

/// <summary>
/// Boss movement.
/// </summary>
public class BossMovement : MonoBehaviour {
	///Check if the boss is damaged.
	public bool damaged;
	///Flip the direction he is moving.
	public bool flip = false;
	///max movement speed.
	public float maxSpeed = 1.5f;
	///The force at which the boss moves to reach max speed.
	private float moveForce = 25f;

	///Health manager
	private EnemyHealthManager myHealth;
	///Current direction
	private int direction = 1;
	///The boss body.
	private Rigidbody2D bossBody;


	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		damaged = false;
		///Find boss components
		bossBody = GetComponent<Rigidbody2D> ();
		myHealth = GetComponent<EnemyHealthManager> ();
	
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {

		///Boss movement
		if (direction == 1) {
			///Check velocities and add force based on direction
			if (bossBody.velocity.x < maxSpeed) {
				bossBody.AddForce (Vector2.right * 1 * moveForce);
			}
		} else {
			if (-bossBody.velocity.x < maxSpeed) {
				bossBody.AddForce (Vector2.left * 1 * moveForce);
			}
		}

		///Check if damages to update boss health controller.
		if (myHealth.damaged == true) {
			damaged = true;
		}
		if (damaged == true) {
			///Play boss flash.
			gameObject.GetComponent<Animation>().Play ("Boss_RedFlash");
			damaged = false;
			myHealth.damaged = false;
		}

		///Flip if flip is true.
		if (flip == true) {
			Flip ();
			flip = false;
		}
	}

	/// <summary>
	/// Flip this instance.
	/// </summary>
	void Flip() {
		direction = direction *= -1;
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col){
		///If a wall is hit flip the boss direction.
		if (col.gameObject.tag == "Solid"){
			flip = true;
		}
	}
}
