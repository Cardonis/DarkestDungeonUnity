using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public bool inCombat;
    public static CharacterController instance;
    public Button endTurnButton;

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

    private void Update()
    {
        if (inCombat)
        {
            if (CombatManager.instance.currentFighter.isCharacter)
            {
                endTurnButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                endTurnButton.GetComponent<Button>().interactable = false;
            }

        }
    }
}
