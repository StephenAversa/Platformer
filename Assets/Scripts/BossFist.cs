using UnityEngine;
using System.Collections;

/// <summary>
/// Boss fist.
/// </summary>
public class BossFist : MonoBehaviour {
	/// Check for attacking
	public bool attack = false;
	/// Check if it can attack
	public bool canAttack = true;
	/// Delay between attacks
	public float delay = .25f;
	/// Interval time for attacks
	public float nextAttack = 4;
	/// Time for idle attack
	public float idleAttack;

	/// The player character
	private PlayerControl Player;
	/// The animator
	private Animator anim;


	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		anim = GetComponent<Animator>();
		idleAttack = 2;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update(){
		anim.SetBool ("Attack", attack);
		delay -= 1 * Time.deltaTime;
		nextAttack -= 1 * Time.deltaTime;
		if (delay <= 0) {
			attack = false;
		}
		if (nextAttack <= 0) {
			canAttack = true;
		}

		idleAttack -= 1 * Time.deltaTime;
		if (idleAttack <= 0 && canAttack == true) {
			attack = true;
			idleAttack = 2;
		}

	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			///Check to see if the player is there and it can attack
			if (col.CompareTag ("Player") && canAttack == true) {
				canAttack = false;
				delay -= .25f;
				attack = true;
				nextAttack = 4;
				///Inflict damage on the player
				if (attack == true){
					Player.inflictDamage (1);
					StartCoroutine (Player.KnockBack (0.1f, 150, -(transform.position - col.transform.position).normalized));
				}
			}
		}
	}
	/// <summary>
	/// Raises the trigger stay 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D(Collider2D col){
		if (col.isTrigger != true) {
			if (col.CompareTag ("Player") && canAttack == true) {
				canAttack = false;
				delay -= .25f;
				attack = true;
				nextAttack = 4;
				///Inflict damage on the player
				if (attack = true){
					Player.inflictDamage (1);
					StartCoroutine (Player.KnockBack (0.1f, 150, -(transform.position - col.transform.position).normalized));
				}
			}
		}
	}
}
