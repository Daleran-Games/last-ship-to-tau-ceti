﻿using UnityEngine;
using System.Collections;

namespace DaleranGames
{
    public class Quit : MonoBehaviour
    {

        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
        }

    }
}

