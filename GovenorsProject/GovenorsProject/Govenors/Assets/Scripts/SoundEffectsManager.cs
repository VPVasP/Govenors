using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance;
    public AudioClip enemyAttackSound;
    public AudioClip enemyHurtSound;
    public AudioClip enemyDeathSound;
    private void Awake()
    {
        instance = this;
    }
}
