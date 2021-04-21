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
    public List<Transform> playerAnchors;
    public List<Transform> ennemiesAnchors;
    public GroupManager playerGroup, ennemiGroup;

    private void Awake()
    {
        if (instance== null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
    }
    public void StartFight(/*GroupManager playerGroup, GroupManager ennemiGroup*/)
    {
        for (int i=0; i<playerGroup.group.Count; i++)
        {
            fighters.Add(playerGroup.group[i].entity);
        }
        for (int j = 0; j < ennemiGroup.group.Count; j++)
        {
            fighters.Add(ennemiGroup.group[j].entity);
        }
        NewRound();
    }
    public void NewRound()
    {
        CharacterController.instance.inCombat = true;
        roundTacker++;
        currentFighter = null;
        turnNumber = 0;
        Debug.Log("Round : " + roundTacker);

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
        if (turnNumber < fighters.Count)
        {
            currentFighter = fighters[turnNumber];
            currentFighter.hasPlayed = true;
            currentFighter.canPlay = true;
            Debug.Log("Tour de : " + currentFighter);
            if (currentFighter.isCharacter)
                CharacterController.instance.ActivatePlayerController();
        }
        else
        {
            NewRound();
        }
    }

    public void EndTurn()
    {
        currentFighter.canPlay = false;
        if (currentFighter.isCharacter)
            CharacterController.instance.DesactivatePlayerController();
        turnNumber++;
        NewTurn();
    }

    public void ExecuteAction()
    {

    }
}
