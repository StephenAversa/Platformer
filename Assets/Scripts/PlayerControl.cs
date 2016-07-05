using UnityEngine;
using System.Collections;
/// <summary>
/// Player control.
/// </summary>
public class PlayerControl : MonoBehaviour {
	[HideInInspector]
	/// For determining which way the player is currently facing.
	public bool facingRight = true;			
	[HideInInspector]
	/// Condition for whether the player should jump.
	public bool jump = false;
	
	/// Condition for whether or not the player is powered up.
	public bool power;
	/// Timer for how long the player is invincible.
	public float poweredTime;
	
	/// Amount of force added to move the player left and right.
	public float moveForce = 365f;	
	/// The fastest the player can travel in the x axis.
	public float maxSpeed = 5f;
	/// Amount of force added when the player jumps.
	public float jumpForce = 1000f;
	/// Amount of force added when the player double jumps.
	public float jump2Force = 750f;

	/// A position marking where to check if the player is grounded.
	private Transform groundCheck;
	/// Boolean to check whether or not the player is on the ground.
	public bool grounded = false;			
	/// Whether or not the player is grounded.
	public bool doubleJump = false;
	/// Whether or not the player is damaged.
	public bool damaged = false;
	///Time the player is invincible
	public float invinc;
	/// The animator for the object.
	private Animator anim;

	///The Players current health.
	public int curHealth = 3;
	///The Players max health
	public int maxHealth = 3;

	private Sword Sword;

	/// <summary>
	/// Start this instance.
	/// </summary>
	public void Start () {
		invinc = 1.5f;
		///On start set the current health to the max health of the player.
		curHealth = maxHealth;
		Sword = GameObject.FindGameObjectWithTag ("Sword").GetComponent<Sword> ();
		
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	public void Awake()
	{
		/// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	public void Update()
	{
		/// The player is grounded if the groundcheck position hits anything on the ground layer.
		anim.SetBool ("Grounded", grounded);
		invinc -= 1 * Time.deltaTime;
		curHealth = 3;
		
		/// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump")){
			///If grounded set the variables for jump and double jump to true.
			if (grounded){
				jump = true;
				doubleJump = true;
			}else{
				///If can double jump while in the air then apply the jump;
				if (doubleJump == true){
					GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump2Force));
					doubleJump = false;
				}
			}

		}

		///Setters to ensure the health cannot exceed max
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		///Setters to ensure the health cannot drop below zero. Kill the game if it does.
		if (curHealth <= 0){
			curHealth = 0;
			Die();
		}

		if (power == true) {
			Sword.PowerOn(10);
			power = false;
		}
		if (invinc < 0) {
			damaged = false;
		}
	}
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	public void FixedUpdate (){
		///Get the horizontal input for the player.
		float h = Input.GetAxis ("Horizontal");
		
		///Set the speed parameter for the animator object.
		anim.SetFloat ("Speed", Mathf.Abs (h));
		
		/// If the player hasnt reached max speed.
		if (h * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed)
			///Add force
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce);
		
		/// If the player hasnt reached max speed.
		if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed)
			///Add force
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
		///Check the horizontal movement left
		if (h > 0 && !facingRight)
			/// Flip the player
			Flip ();
		///Check the horizontal movement right
		else if (h < 0 && facingRight)
			/// Flip the player
			Flip ();

		/// Check for the jump.
		if(jump)
		{	
			/// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			
			/// Make sure the player can't jump again until jump is true.
			jump = false;
		}
	}
	/// <summary>
	/// Flip this instance.
	/// </summary>
	public void Flip ()
	{
		/// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		/// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	/// <summary>
	/// Inflicts the damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public void inflictDamage(int damage){
		if (damaged == false) {
			curHealth -= damage;
			damaged = true;
			///Apply the red flash animation.
			gameObject.GetComponent<Animation> ().Play ("Char_RedFlash");
		}
		invinc = 1.5f;
	}

	/// <summary>
	/// Adds the health.
	/// </summary>
	/// <param name="add">Add.</param>
	public void addHealth(int add){
		curHealth++;
	}

	/// <summary>
	/// Knocks the back.
	/// </summary>
	/// <returns>The back.</returns>
	/// <param name="knockDur">Knock duration.</param>
	/// <param name="knockBackPwr">Knock back powr.</param>
	/// <param name="knockBackDir">Knock back direction.</param>
	public IEnumerator KnockBack(float knockDur, float knockBackPwr, Vector3 knockBackDir){
		///The timer for duration of the knockback.
		float timer = 0;

		while (knockDur > timer) {
			///Set the timer for the knocback to count down so the knockback stops.
			timer += Time.deltaTime;
			GetComponent<Rigidbody2D>().AddForce(new Vector3(knockBackDir.x * -100, knockBackDir.y * knockBackPwr, transform.position.z));
		}

		yield return 0;
	}

	/// <summary>
	/// When the player dies.
	/// </summary>
	public void Die(){
		//Reload the level
		Application.LoadLevel(Application.loadedLevel);
	}
}
