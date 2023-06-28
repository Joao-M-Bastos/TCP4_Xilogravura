using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManger : MonoBehaviour
{
    [SerializeField] AudioSource violas;
    // Start is called before the first frame update
    void Start()
    {
        violas.mute = !GoToSceneScript.GetSound();
    }

    public void UpdateMute()
    {
        violas.mute = !GoToSceneScript.GetSound();
    }
}
