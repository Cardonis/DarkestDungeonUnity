using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public static CharacterController instance;
    public bool inCombat;
    public Button endTurnButton;
    public GameObject playerCombatInterface;
    public List<Button> combatButtons;
    public Entity currentCharacter;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        for (int i=0; i < playerCombatInterface.transform.childCount; i++)
        {
            combatButtons.Add(playerCombatInterface.transform.GetChild(i).transform.GetComponent<Button>());
        }
    }
    void Update()
    {
        if (inCombat)
        {
            
        }
    }

    public void ActivatePlayerController()
    {
        inCombat = true;
        currentCharacter = CombatManager.instance.currentFighter;
        for (int i = 0; i < playerCombatInterface.transform.childCount; i++)
        {
            combatButtons[5].GetComponent<Button>().interactable = true;
        }
    }
    public void DesactivatePlayerController()
    {
        inCombat = false;
        for (int i = 0; i < playerCombatInterface.transform.childCount; i++)
        {
            combatButtons[5].GetComponent<Button>().interactable = false;
        }
    }

    private void UseCapacity()
    {

    }
}
