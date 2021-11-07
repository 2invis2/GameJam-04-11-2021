using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalIntro : MonoBehaviour
{
    [SerializeField]
    private AudioSource intro;

    void Update()
    {
        //Debug.Log(intro.time);
        if (intro.time >= 126.0f)
        {
            OpenNextScene();
        }
    }

    public void OpenNextScene()
    {
        Application.LoadLevel(1);
    }
}
