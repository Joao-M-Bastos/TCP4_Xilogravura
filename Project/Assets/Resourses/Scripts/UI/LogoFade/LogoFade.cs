using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFade : MonoBehaviour
{
    Animator logoAnimator;

    private void Awake()
    {
        logoAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (logoAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadedIn"))
        {
            GoToSceneScript.GoToScene("StarterMenuScene");
        }
    }
}
