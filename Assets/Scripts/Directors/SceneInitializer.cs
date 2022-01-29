﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Directors
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] PlayerEntity player;

        void Start() => 
            player.Initialize();
    }
}