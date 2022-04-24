using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public GameObject NextLevelCanvas;
    public Timer timer;

    public void NextLevel()
    {
        timer.ResetTimer();
    }
}
