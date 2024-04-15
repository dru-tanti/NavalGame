using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ship", order = 0)]
public class ShipData : ScriptableObject {
	public float size = 1;
	public float acceleration = 2;
	public float speed = 5;

	[Header("Attack")]
	public int maxAmmunition = 20;
	[Tooltip("How many projectiles will be fired from each side.")]
	public int guns = 1;

	[Header("Health")]
	public int maxHealth;
	[Tooltip("Health value below which the ship will be considered 'damaged'.")]
	public int damagedThreshold;
	[Tooltip("Health value below which the ship will be considered 'sinking'.")]
	public int sinkingThreshold;

	[Header("Sprites")]
	public Sprite undamagedSprite;
	public Sprite damagedSprite;
	public Sprite sinkingSprite;
}