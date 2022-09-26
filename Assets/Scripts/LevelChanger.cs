using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int _levelToLoad;
    


    public void FadeToLevel(int levelIndex)
    {
        _levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
