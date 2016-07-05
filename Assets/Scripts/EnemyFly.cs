using UnityEngine;
using System.Collections;
/// <summary>
/// Enemy fly.
/// </summary>
public class EnemyFly : MonoBehaviour {
	/// The player.
	private PlayerControl Player;
	/// The player layer mask.
	public LayerMask playerLayer;
	/// The move speed of the enemy.
	public float moveSpeed;
	/// The max range for seeking the player.
	public float playerRange;
	/// Check if the player is inside the range.
	public bool playerIn;
	/// Check if the player is damaged.
	public bool damaged;
	/// The health manager.
	private EnemyHealthManager myHealth;
	Vector3 newPos;

	///Idle Settings, Interval and Change.
	public float changeInterval = .5f;
	public float changeTimer= 2;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		myHealth = GetComponent<EnemyHealthManager> ();
		newPos= new Vector3 (Random.Range(-200,200),Random.Range(-200,200),0);
		transform.position = Vector3.MoveTowards (transform.position, newPos, moveSpeed / 4 * Time.deltaTime);

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		playerIn = Physics2D.OverlapCircle(transform.position,playerRange,playerLayer);

		changeTimer += Time.deltaTime;
		Debug.Log (newPos);
		///If player is inside the range.
		if (playerIn) {
			///Move towards the player.
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
		} else {
			{
			transform.position = Vector3.MoveTowards (transform.position, newPos, moveSpeed/4 * Time.deltaTime);
			}
		}
		///Change direction when idle.
		changeDirection ();


		if (myHealth.damaged == true) {
			damaged = true;
		}
		///Check to see if damaged.
		if (damaged == true) {
			///Play flash if damaged.
			gameObject.GetComponent<Animation>().Play ("Fly_RedFlash");
			damaged = false;
			myHealth.damaged = false;
		}
	}

	/// <summary>
	/// Changes the direction.
	/// </summary>
	public void changeDirection(){
		///Check the timer, then change the direction.
		if (changeTimer > changeInterval) {
			newPos= new Vector3 (Random.Range(-200,200),Random.Range(-200,200),0);
			changeTimer = 0;
		}
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Player")) {
			///Inflict damage on the player.
			Player.inflictDamage (1);
			StartCoroutine (Player.KnockBack (0.1f, 100, -(col.transform.position - transform.position).normalized));
		}
	}
	
}
