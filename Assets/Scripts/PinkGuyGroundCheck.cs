using UnityEngine;
using System.Collections;

/// <summary>
/// Pink guy ground check.
/// </summary>
public class PinkGuyGroundCheck : MonoBehaviour {

	/// The enemy reference
	private PinkGuy enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		enemy = gameObject.GetComponentInParent<PinkGuy> ();
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (!col.CompareTag ("Enemy")) {
			enemy.grounded = true;
		}
	}

	/// <summary>
	/// Raises the trigger stay2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerStay2D(Collider2D col){
		if (!col.CompareTag ("Enemy")) {
			enemy.grounded = true;
		}
	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerExit2D(Collider2D col){
		enemy.grounded = false;
	}
}
