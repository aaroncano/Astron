﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public void clilcsound()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }
}
