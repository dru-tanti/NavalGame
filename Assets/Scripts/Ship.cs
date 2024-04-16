using UnityEngine;

[RequireComponent(typeof(Health), typeof(Attack))]
public class Ship : MonoBehaviour {
    public ShipData ship;
	protected float rotation;
	protected Collider2D _collider;
	protected Rigidbody2D _rigidbody;
	protected Health health;
	protected Attack attack;
	private float rotationInterpolation;
	private float turnSpeed = 0.05f;

	protected void Awake() {
		_rigidbody  = gameObject.GetComponent<Rigidbody2D>();
		_collider   = gameObject.GetComponent<Collider2D>();
		health		= gameObject.GetComponent<Health>();
		attack		= gameObject.GetComponent<Attack>();

		transform.localScale = new Vector3(ship.size, ship.size, ship.size);
		health.Setup(ship);
		attack.Setup(ship);
	}

	protected void Move(Vector2 direction) {
		_rigidbody.AddForce(direction * ship.acceleration);
		float targetRotation = Mathf.Atan2(direction.y, direction.x) * (180/Mathf.PI) + 90;
		rotation = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref rotationInterpolation, turnSpeed);
		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}
}
