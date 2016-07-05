using UnityEngine;
using System.Collections;

/// <summary>
/// Pink guy ahead check.
/// </summary>
public class PinkGuyAheadCheck : MonoBehaviour {

	/// The enemy
	private PinkGuy enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		///Reference
		enemy = gameObject.GetComponentInParent<PinkGuy> ();
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (!col.CompareTag("Enemy")){
			enemy.checkAhead = true;
		}
	}

	/// <summary>
	/// Raises the trigger stay2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerStay2D(Collider2D col){
		if (!col.CompareTag("Enemy")){
			enemy.checkAhead = true;
		}
	}

	/// <summary>
	/// Raises the trigger exit 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerExit2D(Collider2D col){
		///Set the check ahead to false.
		enemy.checkAhead  = false;
	}
}

