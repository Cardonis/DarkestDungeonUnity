using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManage
{

    public Ennemi thisEnnemi;
    public List<Entity> pcAffected;
    public List<Entity> ennemiAffected;


    public virtual IEnumerator Action()
    {
        yield return null;
    }
}
