using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Health), typeof(Attack))]
public class PlayerController : MonoBehaviour {
	public Ship ship;
	private float rotation;
	private PlayerInput _input;
	private Collider2D _collider;
	private Rigidbody2D _rigidbody;
	private Health health;
	private Attack attack;
	public float rotationInterpolation;
	public float turnSpeed = 0.05f;


	private void Awake() {
		_input      = new PlayerInput();
		_rigidbody  = gameObject.GetComponent<Rigidbody2D>();
		_collider   = gameObject.GetComponent<Collider2D>();
		health		= gameObject.GetComponent<Health>();
		attack		= gameObject.GetComponent<Attack>();

		transform.localScale = new Vector3(ship.size, ship.size, ship.size);
		health.SetValue(ship.maxHealth);
		attack.SetValue(ship.guns, ship.maxAmmunition);
	}

	private void OnEnable() {
		_input.Movement.Enable();
	}

	private void OnDisable() {
		_input.Movement.Disable();
	}

	private void FixedUpdate() {
		Move(_input.Movement.Move.ReadValue<Vector2>());
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.transform.tag == "Land") {
			health.TakeDamage(50);
		}
	}

	private void Move(Vector2 direction) {
		_rigidbody.AddForce(direction * ship.acceleration);
		float targetRotation = Mathf.Atan2(direction.y, direction.x) * (180/Mathf.PI) + 90;
		rotation = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref rotationInterpolation, turnSpeed);
		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}

	private void OnFireLeft(InputValue value) {
		attack.Fire(GunPosition.Left);
	}

	private void OnFireRight(InputValue value) {
		attack.Fire(GunPosition.Right);
	}
}
