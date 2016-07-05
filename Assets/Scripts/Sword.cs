using UnityEngine;
using System.Collections;
/// <summary>
/// Sword.
/// </summary>
public class Sword : MonoBehaviour {

	/// The animation.
	private Animator anim;
	/// Boolean to check if attack is happening.
	public bool attack = false;
	/// Timer for when the next attack can occur
	public float nextAttack = 0;
	/// Up swing is the duration of the time it takes for the sword to be drawn once again.
	public float upSwing = .25f;
	/// The current damage of the sword.
	public int dmg;

	public bool powered = false;
	public float poweredTimer;


	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool ("Attack", attack);
		dmg = 1;

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		if (Input.GetButtonDown ("Attack") && Time.time > nextAttack) {
			nextAttack = Time.time + upSwing;
			attack = true;
		}

		if (powered == true) {
			gameObject.GetComponent<Animation>().Play ("Sword_BlueFlash");
			poweredTimer -= 1 * Time.deltaTime;
			if (poweredTimer <= 0){
				dmg = 1;
				powered = false;
			}
		}
	}
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	public void FixedUpdate (){	
		anim.SetBool ("Attack", attack);
		if (attack == true && Time.time > nextAttack) {
			nextAttack = Time.time + upSwing;
			attack = false;
		}
	}
	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		///If the unit being attack is an enemy or boss inflict damage.
		if (col.CompareTag("Enemy") || col.CompareTag("Boss")){
			if (attack == true){
				col.GetComponent<EnemyHealthManager>().inflictDamage(dmg);
			}
		}
	}
	/// <summary>
	/// Raises the trigger stay 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerStay2D(Collider2D col){
		///If the unit being attack is an enemy or boss inflict damage.
		if (col.CompareTag("Enemy") || col.CompareTag("Boss")){
			if (attack == true){
				col.GetComponent<EnemyHealthManager>().inflictDamage(dmg);
			}
		}
	}
	/// <summary>
	/// Powers the sword up.
	/// </summary>
	/// <param name="timer">Timer.</param>
	public void PowerOn(int timer){
		dmg = 2;
		powered = true;
		///Assign the duration of the powerup
		poweredTimer = timer;
	}

}
