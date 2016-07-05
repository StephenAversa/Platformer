using UnityEngine;
using System.Collections;
/// <summary>
/// Pink guy.
/// </summary>
public class PinkGuy : MonoBehaviour {

	/// The direction.
	private int direction = 1;
	/// The move force.
	private float moveForce = 10f;
	/// The max speed
	public float maxSpeed = 5f;
	/// Check to see if flip
	public bool flip = false;
	/// Check to see if grounded.
	public bool grounded;
	/// Jump force
	public float jumpForce = 75f;
	/// Check in front of the enemy
	public bool checkAhead;
	/// Check to see if can jump over obstacle.
	public bool jumpCheck;

	/// The player.
	private PlayerControl Player;
	/// Range to find player.
	public float playerRange = 10;
	/// Check to see if can see the player.
	public bool canSeePlayer;
	/// check to see if can attack.
	public bool canAttack;

	/// The timer for the throw.
	public float bulletTimer;
	/// The interval for the throw
	public float shootInterval;
	/// The throw object.
	public GameObject PinkThrow;
	/// The speed at which the object is thrown.
	public float throwSpeed = 5;

	/// The attack timer.
	public float attackTimer;
	/// The attack interval.
	public float attackInterval;

	/// Check to see if damaged.
	public bool damaged;

	/// Health reference
	private EnemyHealthManager myHealth;
	/// Rigidbody reference
	private Rigidbody2D rBody;
	/// The animation reference.
	private Animator anim;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///Set the references
		canAttack = true;
		jumpCheck = true;
		rBody = GetComponent<Rigidbody2D> ();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		anim = GetComponent<Animator>();
		myHealth = GetComponent<EnemyHealthManager> ();
	
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update(){
		///Check to see if can jump.
		if (checkAhead && jumpCheck && grounded && !canSeePlayer) {
			///Jump
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));
		}
		///Set the animation
		anim.SetBool ("Grounded", grounded);
		//anim.SetFloat ("Speed", canSeePlayer);
	}
	
	/// <summary>
	/// Fixed update.
	/// </summary>
	public void FixedUpdate () {
		///Direction to move
		if (!canSeePlayer) {
			if (direction == 1) {
				if (rBody.velocity.x < maxSpeed) {
					rBody.AddForce (Vector2.right * 1 * moveForce);
				}
			} else {
				if (-rBody.velocity.x < maxSpeed) {
					rBody.AddForce (Vector2.left * 1 * moveForce);
				}
			}
		}

		///Check to see if the character should turn around.
		if (flip == true) {
			Flip ();
			flip = false;
		}
		canSeePlayer = false;
		//Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + playerRange, transform.position.y, transform.position.z));

		///Subtract attack timer.
		attackTimer = Time.deltaTime;
		LookForPlayer ();
		///Check timer to reset attack
		if (attackTimer > attackInterval) {
			canAttack = true;
			attackTimer = 0;
		}
	
		//Debug.Log (myHealth.health);

		///Check for damage
		if (myHealth.damaged == true) {
			damaged = true;
		}
		if (damaged == true) {
			///Apply the flash
			gameObject.GetComponent<Animation>().Play ("PinkGuy_RedFlash");
			damaged = false;
			myHealth.damaged = false;
		}
	}

	/// <summary>
	/// Attack this instance.
	/// </summary>
	public void Attack(){
		bulletTimer += Time.deltaTime;
		if (bulletTimer > shootInterval) {
			///References
			GameObject pinkThrowClone;
			Rigidbody2D pBody;
			///Create the throwing star
			pinkThrowClone = Instantiate(PinkThrow, transform.position, transform.rotation) as GameObject;
			pBody = pinkThrowClone.GetComponent<Rigidbody2D>();
			///Based on direction apply force to the star.
			if (direction == 1){
				pBody.velocity = Vector2.right * 1 * throwSpeed;
			}else{
				pBody.velocity = Vector2.left * 1 * throwSpeed;
			}
			///Change the direction and reset timer.
			Flip();
			bulletTimer = 0;
		}

	}

	/// <summary>
	/// Looks for player.
	/// </summary>
	public void LookForPlayer(){
		///Checks along the left and right of the character to see if the player is there.
		if (transform.localScale.x > 0 && Player.transform.position.x > transform.position.x && Player.transform.position.x < transform.position.x + playerRange) {
			if (canAttack){
				///If the plater is there attack.
				canSeePlayer = true;
				Attack ();
			}
		}
		if (transform.localScale.x < 0 && Player.transform.position.x < transform.position.x && Player.transform.position.x > transform.position.x - playerRange) {
			if (canAttack){
				canSeePlayer = true;
				Attack ();
			}
		}

	}

	/// <summary>
	/// Flip this instance.
	/// </summary>
	public void Flip() {
		///Flip the image
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		direction = direction *= -1;
	}
}
