using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private Dictionary<string, AudioSource> sounds;

    private void Awake()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            GameObject curr = transform.GetChild(i).gameObject;
            if (curr.TryGetComponent(out AudioSource audio))
            {
                sounds.Add(curr.name, audio);
            }
        }
    }

    public void OnSoundPlay(string soundName)
    {
        if (sounds.Keys.Contains(soundName))
            sounds[soundName].Play();
    }

    public void OnDie()
    {
        OnSoundPlay("Die");
    }
    
    public void OnAttack()
    {
        OnSoundPlay("Attack");
    }
    public void OnFound()
    {
        OnSoundPlay("Found");
    }

}
