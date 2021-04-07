using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Entity
{

    public char type;

    private void Update()
    {
        if(CombatManager.instance.currentFighter == this)
        {
            TakeTurn();
        }
    }
    public void TakeTurn()
    {

        if (canPlay && hasPlayed)
        {
            SpearThrust();
        }
    }
    public void SpearThrust()
    {
        Debug.Log("SPEEEEAR!");
        CombatManager.instance.EndTurn();
    }
}
