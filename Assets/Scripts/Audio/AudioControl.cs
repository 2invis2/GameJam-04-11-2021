using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public GameObject die;
    public void OnDie()
    {
        if (die != null)
            Instantiate(die, transform.position, quaternion.identity);
    }
}
