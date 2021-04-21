using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroupManager : MonoBehaviour
{
    public bool isPlayerGroup;
    public List<GroupOrder> group;
    public List<Transform> currentAnchors;
    public bool poseUpdate;
    private float poseUpdateCD;

    public void Start()
    {
        group = new List<GroupOrder>();
        for (int i=0; i<gameObject.transform.childCount; i++)
        {
            group.Add(new GroupOrder(gameObject.transform.GetChild(i).gameObject.GetComponent<Entity>()));
        }
        if (isPlayerGroup)
        {
            currentAnchors = new List<Transform>();
            for(int i =0; i < CombatManager.instance.playerAnchors.Count; i++)
            currentAnchors.Add(CombatManager.instance.playerAnchors[i]);

        }
        else
        {
            currentAnchors = new List<Transform>();
            currentAnchors = CombatManager.instance.ennemiesAnchors;
        }
    }
    private void Update()
    {
        if (poseUpdate)
        {

            for (int i = 0; i < group.Count; i++)
            {
                group[i].entity.entityGameObject.transform.position = Vector3.MoveTowards(group[i].entity.entityGameObject.transform.position, currentAnchors[i].position, 10 * Time.deltaTime);
            }
            if(poseUpdateCD <= 1.5f)
            {
                poseUpdateCD  += Time.deltaTime;
            }
            else
            {
                poseUpdate = false;
                poseUpdateCD = 0;
            }
        }
    }
    public void ForwardInGroup(Entity moving, int futurePose)
    {
        for(int i=moving.positionInGroup; i<futurePose; i++)
        {
            if (futurePose <= group[i].pose)
            {
                group[i].pose++;
            }
            else
            {
                moving.positionInGroup = futurePose;
            }
        }
        poseUpdate = true;
    }
    public void BackwardInGroup(Entity moving, int futurePose)
    {

        for (int i = moving.positionInGroup; i > futurePose; i--)
        {
            if (futurePose >= group[i].pose)
            {
                group[i].pose--;
            }
            else
            {
                moving.positionInGroup = futurePose;
            }
        }
        SetGroupPose();
    }

    public void SetGroupPose()
    {
        group.Sort();
        poseUpdate = true;
    }
}

public class GroupOrder : IComparable<GroupOrder>
{

    public Entity entity;
    public int pose;
    public GroupOrder(Entity thisEntity)
    {
        entity= thisEntity;
        pose = entity.positionInGroup;
    }
    public int CompareTo(GroupOrder other)
    {

        if (pose < other.pose)
        {
            return 1;
        }
        if (entity.positionInGroup > other.pose)
        {
            return -1;
        }
        return 0;
    }
}
