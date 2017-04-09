/*
 * This script was created to manage whether or not the player is in the menus, the local version of the game,
 * or the online version. This way if using a ridgid body for movement is to copmlex for server side logic, you
 * can use a different movement system for networked games that allows the server to update the users position.
 */
 
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
