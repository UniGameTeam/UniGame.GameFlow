﻿using UnityEngine;

namespace UniGame.UniNodes.Examples.SimpleCustomNode
{
    using NodeSystem.Runtime.Attributes;
    using NodeSystem.Runtime.Core;
    using NodeSystem.Runtime.ReactivePorts;

    [CreateNodeMenu("Examples/SimpleCustomNodes/SimpleNode",nodeName = "Simple Node")]
    public class SimpleDemoNode : UniNode
    {

        [SerializeField]
        private int intDataOne;
    
        public int intDataTwo;

        [PortValue(PortIO.Input)]
        public int inInt;

        [PortValue(PortIO.Output)] 
        public float outInt;

        [ReactivePort()]
        public IntReactivePort inReactiveInt;

    }
}
