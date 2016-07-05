using UnityEngine;
using System.Collections;

/// <summary>
/// Pink guy movement.
/// </summary>
public class PinkGuyMovement : MonoBehaviour {

	/// The enemy reference
	private PinkGuy enemy;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start(){
		enemy = gameObject.GetComponentInParent<PinkGuy> ();

	}

	/// <summary>
	/// Raises the trigger enter 2d event.
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Solid"){
			enemy.flip = true;
		}
		if (col.gameObject.tag == "Enemy"){
			enemy.flip = true;
		}
	}
}
