using UnityEngine;

[RequireComponent(typeof(Health))]
public class Ship : MonoBehaviour {
    public ShipData ship;
	protected float rotation;
	protected bool isPorted = false;
	protected Collider2D _collider;
	protected Rigidbody2D _rigidbody;
	protected Health health;

	private float rotationInterpolation;
	private float turnSpeed = 0.05f;
	[Range(1f, 1.5f)]
	public float drag = 1.02f;
	
	protected void Awake() {
		_rigidbody  = gameObject.GetComponent<Rigidbody2D>();
		_collider   = gameObject.GetComponent<Collider2D>();
		health		= gameObject.GetComponent<Health>();

		transform.localScale = new Vector3(ship.size, ship.size, ship.size);
		health.Setup(ship);
	}

	protected void Move(Vector2 direction) {
		_rigidbody.AddForce(direction * ship.acceleration);
		_rigidbody.velocity /= drag;
		float targetRotation = Mathf.Atan2(direction.y, direction.x) * (180/Mathf.PI) + 90;
		rotation = Mathf.SmoothDampAngle(transform.eulerAngles.z, targetRotation, ref rotationInterpolation, turnSpeed);
		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}
}
