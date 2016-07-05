using UnityEngine;
using System.Collections;

/// <summary>
/// Camera controller.
/// </summary>
public class CameraController : MonoBehaviour {

	/// Target for bullets.
	public GameObject targetObject;
	/// Rigidbody for the target.
	private Rigidbody2D targetRb;
	/// Player character.
	private PlayerControl Player;

	/// Difference between current position and camera.
	private Vector3 difference;
	/// Velocity to move camera.
	private Vector3 velocity = Vector2.zero;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		targetRb = targetObject.GetComponent<Rigidbody2D>();
		difference = transform.position - targetObject.transform.position;
	}

	/// <summary>
	/// Delays the update.
	/// </summary>
	public void LateUpdate() {
		move(targetRb.velocity / 2f);
	}

	/// <summary>
	/// Move at the specified velocit.
	/// </summary>
	/// <param name="vel">Vel.</param>
	public void move(Vector3 vel) {
		transform.position = Vector3.SmoothDamp(transform.position, targetObject.transform.position + difference, ref velocity, 0.25f);
	}
	
}