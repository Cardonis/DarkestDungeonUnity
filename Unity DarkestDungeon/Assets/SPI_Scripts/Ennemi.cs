using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Entity
{
    public List<ActionManage> actionSet;
    public char type;
    public int currentAction;

    public virtual void Awake()
    {
        actionSet = new List<ActionManage>();
    }
    private void Update()
    {
        if(CombatManager.instance.currentFighter == this)
        {
            TakeTurn();
        }
    }
    public void TakeTurn()
    {

        currentAction = 0;
        if (canPlay && hasPlayed)
        {
            hasPlayed = false;
            ChooseAction();
        }
    }

    public void ChooseAction()
    {
        currentAction = Random.Range(0,actionSet.Count);
        StartCoroutine(actionSet[currentAction].Action());
    }
}
