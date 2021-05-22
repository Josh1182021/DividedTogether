using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    [SerializeField] int levelUnlocked = 1;

    public void UnlockLevel(int newUnlockedLevel)
    {
        if (newUnlockedLevel > levelUnlocked)
            levelUnlocked = newUnlockedLevel;
    }

    public int GetLevelUnlocked()
    {
        return levelUnlocked;
    }

}
