﻿using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
