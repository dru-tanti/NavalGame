using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Ship {
	private PlayerInput _input;

    private new void Awake() {
		base.Awake();
		_input      = new PlayerInput();
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

	private void OnFireLeft(InputValue value) {
		attack.Fire(GunPosition.Left);
	}

	private void OnFireRight(InputValue value) {
		attack.Fire(GunPosition.Right);
	}
}
