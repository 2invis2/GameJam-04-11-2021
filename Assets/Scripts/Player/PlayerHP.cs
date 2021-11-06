using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public void ProjectileHit(GameObject killer)
    {
        Debug.Log(killer.name + " murdered u");
    }
}
