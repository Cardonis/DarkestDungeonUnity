using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour, IComparable<Entity>
{
    public bool isCharacter;
    //BASE STATS
    public int maxHp;
    public float dodge;
    public float prot;
    public int speed;


    //BASE RESIST
    public float stunResist;
    public float moveResist;
    public float blightResist;
    public float bleedResist;
    public float debufResist;

    //public List<Effect> currentEffects;


    public int currentHp;
    public int initiative;
    public bool canPlay;
    public bool hasPlayed;


    public GameObject entityGameObject;
    public int positionInGroup;
    void Start()
    {
        entityGameObject = gameObject;
    }

    public int CompareTo(Entity other)
    {

        if (initiative < other.initiative)
        {
            return 1;
        }
        if (initiative > other.initiative)
        {
            return -1;
        }
        return 0;
    }


}
