using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Attack))]
public class PlayerController : Ship {
	private PlayerInput _input;
	protected Attack attack;
    private new void Awake() {
		base.Awake();
		_input      = new PlayerInput();
		attack		= gameObject.GetComponent<Attack>();
		attack.Setup(ship);
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
			Debug.Log("Hit Land!");
			health.TakeDamage(50);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.transform.tag == "Port") {
			Debug.Log("In Port!");
			isPorted = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.transform.tag == "Port") {
			Debug.Log("Exited Port!");
			isPorted = false;
		}
	}

	private void OnFireLeft(InputValue value) {
		attack.Fire(GunPosition.Left);
	}

	private void OnFireRight(InputValue value) {
		attack.Fire(GunPosition.Right);
	}
}
