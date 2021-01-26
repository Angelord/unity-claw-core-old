﻿using UnityEngine;

namespace Claw.AI.Steering {
    public interface ISteeringBehaviour {

        bool Enabled { get; set; } 

        Vector2 Calculate();
    }
}