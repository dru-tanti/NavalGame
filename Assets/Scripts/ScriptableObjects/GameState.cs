using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState", order = 0)]
public class GameState : ScriptableObject {
	public ShipData playerShip;
	public List<ShipData> merchants;
	public List<ShipData> warships;
}