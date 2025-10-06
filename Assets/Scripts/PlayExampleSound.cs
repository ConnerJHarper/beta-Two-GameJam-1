using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExampleSound : MonoBehaviour
{
    public void PlaySound()
    {
        SoundManager.PlaySound(SoundType.ButtonTest1);
    }
}