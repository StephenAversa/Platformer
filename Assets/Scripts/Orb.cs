using UnityEngine;
using System.Collections;

/// <summary>
/// Orb.
/// </summary>
public class Orb : MonoBehaviour {
	/// The player.
	private PlayerControl Player;
	[HideInInspector]
	/// A random number
	public float rand;
	[HideInInspector]
	/// The force to push the orb.
	public float initForce;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		rand = Random.Range(1, 1800);
		///Set random number
		initForce = 900 - rand;

		///Checks to make sure the force is at least a certain amount.
		if (initForce < 300) {
			initForce = 300;
		}
		if (initForce < -300) {
			initForce = -300;
		}
		//Debug.Log (initForce);
		GetComponent<Rigidbody2D>().AddForce(new Vector3 (initForce, 500, 0));
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			///Give the player the powerup.
			if (col.CompareTag ("Player")) {
				Player.power = true;
				///Destroy it
				Destroy (gameObject);
			}

		}
	}
}
