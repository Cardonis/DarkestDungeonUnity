using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkeletonSword : Ennemi
{
    public override void Awake()
    {
        base.Awake();
        actionSet.Add(new GraveYardSlash(this));
        actionSet.Add(new GraveYardStumble(this));
    }
   
}
public class GraveYardSlash : ActionManage
{
    public GraveYardSlash(Ennemi ennemi)
    {
        thisEnnemi = ennemi;
    }
    public override IEnumerator Action()
    {
        if (thisEnnemi.positionInGroup <= 4)
        {

            yield return new WaitForSeconds(1);
            Debug.Log("Slash !");
            CombatManager.instance.EndTurn();
        }
        else
        {
            thisEnnemi.ChooseAction();
        }
    }
}
public class GraveYardStumble : ActionManage
{
    public GraveYardStumble(Ennemi ennemi)
    {
        thisEnnemi = ennemi;
    }
    public override IEnumerator Action()
    {
        if (thisEnnemi.positionInGroup >= 4)
        {

            yield return new WaitForSeconds(1);
            Debug.Log("Stumble !");
            CombatManager.instance.EndTurn();
        }
        else
        {
            thisEnnemi.ChooseAction();
        }
    }
}
