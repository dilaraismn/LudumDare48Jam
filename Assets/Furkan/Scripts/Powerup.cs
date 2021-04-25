﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Furkan.Powerup
{
    [Serializable]
    public class Powerup
    {
        [SerializeField]
        public string name;

        [SerializeField]
        public float duration;

        [SerializeField]
        public UnityEvent startAction;

        [SerializeField]
        public UnityEvent endAction;

        public void Start()
        {
            if (startAction != null)
                startAction.Invoke();
        }

        public void End()
        {
            if (endAction != null)
                endAction.Invoke();
        }

    }
}