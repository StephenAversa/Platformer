using UnityEngine;
using System.Collections;

/// <summary>
/// Pink guy throw.
/// </summary>
public class PinkGuyThrow : MonoBehaviour {

	/// The direction
	public int direction;
	/// The player.
	private PlayerControl Player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update () {
		///Set the rotation of the image
		if (direction == 1) {
			transform.Rotate (0, 0, 10);
		} else {
			transform.Rotate (0, 0, -10);
		}
	
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		if (col.isTrigger != true) {
			if (col.CompareTag ("Player")) {
				Player.inflictDamage (1);
				StartCoroutine (Player.KnockBack (0.1f, 50, -(col.transform.position - transform.position).normalized));
			}
			Destroy (gameObject);
		}
	}
}
