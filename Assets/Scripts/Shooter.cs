using UnityEngine;
using System.Collections;
/// <summary>
/// Shooter.
/// </summary>
public class Shooter : MonoBehaviour {

	/// Flip the player
	private PlayerControl Player;
	/// The player mask
	public LayerMask playerLayer;
	/// Check if the player is in range
	public bool playerIn;
	/// Check to see if can attack.
	public bool canAttack;
	/// Check to see if damaged
	public bool damaged;

	/// The range to search for player
	public float playerRange;
	/// Shoot interval
	public float shootInterval;
	/// The bullet speed.
	public float bulletSpeed = 10f;
	/// The bullet timer
	public float bulletTimer;

	/// The animator.
	private Animator anim;
	/// Direction
	Vector2 myDirection;
	/// The bullet.
	public GameObject Bullet;
	/// The target.
	public Transform target;
	/// The health manager
	private EnemyHealthManager myHealth;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		///References
		canAttack = true;
		damaged = false;
		anim = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		///Find the player
		findPlayer ();
		myHealth = GetComponent<EnemyHealthManager> ();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		playerIn = Physics2D.OverlapCircle(transform.position,playerRange,playerLayer);
		anim.SetBool ("Attack", canAttack);

		///Check to see if player in
		if (playerIn) {
			///Begin attack
			setUpAttack();
		} else {
			/// Otherwise cannot attack
			canAttack = false;
		}

		///Check for damage
		if (myHealth.damaged == true) {
			damaged = true;
		}
		///Apply the damage
		if (damaged == true) {
			///Make flash
			gameObject.GetComponent<Animation>().Play ("Shooter_RedFlash");
			damaged = false;
			myHealth.damaged = false;
		}
	}

	/// <summary>
	/// Sets up attack.
	/// </summary>
	public void setUpAttack(){
		///Get direction of player
		Vector2 direction = target.transform.position - transform.position;
		direction = setDirection (direction);
		//Debug.DrawLine (target.position, transform.position);
		///Attack
		Attack (direction);
		canAttack = true;
	}

	/// <summary>
	/// Attack the specified dir.
	/// </summary>
	/// <param name="dir">Dir.</param>
	public void Attack(Vector2 dir){

		///Bullet timer
		bulletTimer += Time.deltaTime;
		if (bulletTimer > shootInterval) {
			///Create the bullet
			GameObject bulletClone;
			Rigidbody2D bulletBody;
			bulletClone = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
			///Set the bullet speed and direction.
			bulletBody = bulletClone.GetComponent<Rigidbody2D>();
			bulletBody.velocity =  dir * bulletSpeed;
			bulletTimer = 0;
		}
	}

	/// <summary>
	/// Finds the player.
	/// </summary>
	public void findPlayer(){
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		///Set the target
		target = Player.transform;
	}

	/// <summary>
	/// Sets the direction.
	/// </summary>
	/// <returns>The direction.</returns>
	/// <param name="direction">Direction.</param>
	public Vector2 setDirection(Vector2 direction){
		myDirection = direction.normalized;
		return myDirection;
	}

}
