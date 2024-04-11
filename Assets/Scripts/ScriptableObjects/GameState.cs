using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "GameState", order = 0)]
public class GameState : ScriptableObject {
	public Ship playerShip;
	public List<Ship> merchants;
	public List<Ship> warships;
}