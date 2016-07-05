using UnityEngine;
using System.Collections;

/// <summary>
/// Ground check.
/// </summary>
public class GroundCheck : MonoBehaviour {

	/// The player.
	private PlayerControl player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		player = gameObject.GetComponentInParent<PlayerControl> ();
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (!col.CompareTag("Spawner") || !col.CompareTag ("Boss")){
			player.grounded = true;
		}
	}

	/// <summary>
	/// Raises the trigger stay2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerStay2D(Collider2D col){
		if (!col.CompareTag ("Spawner") || !col.CompareTag ("Boss")) {
			player.grounded = true;
		}
	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerExit2D(Collider2D col){
		player.grounded = false;
	}

}
