using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;
    public int roundTacker;
    public List<Entity> fighters;
    public Entity currentFighter;
    public int turnNumber;

    public void NewRound()
    {
        roundTacker++;
        currentFighter = null;
        turnNumber = -1;

        for (int i = 0; i < fighters.Count; i++)
        {
            fighters[i].initiative = fighters[i].speed + Random.Range(1, 9);
            fighters[i].hasPlayed = false;
        }
        fighters.Sort();
        Debug.Log(fighters[0] + " " + fighters[1]);
        NewTurn();
    }
    public void NewTurn()
    {
        turnNumber++;
        currentFighter = fighters[turnNumber];
        currentFighter.hasPlayed = true;
        currentFighter.canPlay = true;
    }
}
