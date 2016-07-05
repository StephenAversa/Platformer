using UnityEngine;
using System.Collections;

/// <summary>
/// Bullet.
/// </summary>
public class Bullet : MonoBehaviour {
	/// The player
	private PlayerControl Player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true) {
			///Inflict damage.
			if (col.CompareTag ("Player")) {
				Player.inflictDamage (1);
				StartCoroutine (Player.KnockBack (0.1f, 50, -(col.transform.position - transform.position).normalized));
			}
			///Destroy object.
			Destroy (gameObject);
		}
	}
}
