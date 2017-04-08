using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager {

    public static States GameState;

	public enum States
    {
        Menu,
        LocalGame,
        NetworkGame
    }
}
