using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public void ProjectileHit(GameObject killer)
    {
        Application.LoadLevel(2);
    }
}
