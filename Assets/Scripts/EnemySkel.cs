using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy skel.
/// </summary>
public class EnemySkel : MonoBehaviour {
	/// Max movement speed.
	public float maxSpeed = 2f;
	/// Check to see if the enemy should flip.
	public bool flip = false;
	/// Check to see if enemy is damaged.
	public bool damaged;
	/// The current direction
	private int direction = 1;
	/// The force at which the enemy will move.
	private float moveForce = 5f;
	/// The rigid body of the enemy.
	private Rigidbody2D rBody;
	/// The player.
	private PlayerControl Player;
	/// The health controller.
	private EnemyHealthManager myHealth;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		///References
		rBody = GetComponent<Rigidbody2D> ();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		myHealth = GetComponent<EnemyHealthManager> ();
		damaged = false;
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	public void FixedUpdate() {

		///Check direction and adjust velocity accordingly.
		if (direction == 1) {
			if (rBody.velocity.x < maxSpeed) {
				rBody.AddForce (Vector2.right * 1 * moveForce);
			}
		} else {
			if (-rBody.velocity.x < maxSpeed) {
				rBody.AddForce (Vector2.left * 1 * moveForce);
			}
		}

		///Flip the enemy.
		if (flip == true) {
			Flip ();
			flip = false;
		}

		///Check for damage and apply it.
		if (myHealth.damaged == true) {
			damaged = true;
		}
		if (damaged == true) {
			///Play the flash animation.
			gameObject.GetComponent<Animation>().Play ("Skel_RedFlash");
			damaged = false;
			myHealth.damaged = false;
		}
	}

	/// <summary>
	/// Flip this instance.
	/// </summary>
	public void Flip() {
		///Flip the image.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		direction = direction *= -1;
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			Player.inflictDamage (1);
			if (direction == 1) {
				///Knockback left.
				StartCoroutine (Player.KnockBack (0.1f, 200, -(col.transform.position - transform.position).normalized));
			}else{
				///Knockback right.
				StartCoroutine (Player.KnockBack (0.1f, 200, -(col.transform.position - transform.position).normalized));
			}
		}
	}
}
