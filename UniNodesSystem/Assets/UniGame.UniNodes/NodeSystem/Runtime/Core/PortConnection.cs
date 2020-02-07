﻿namespace UniGreenModules.UniNodeSystem.Runtime.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class PortConnection
    {
        [SerializeField] public string      fieldName;
        [SerializeField] public UniBaseNode node;
        public                  NodePort    Port => port != null ? port : port = GetPort();

        [NonSerialized] private NodePort port;
        /// <summary> Extra connection path points for organization </summary>
        [SerializeField]
        public List<Vector2> reroutePoints = new List<Vector2>();

        public PortConnection(NodePort port)
        {
            this.port = port;
            node      = port.node;
            fieldName = port.fieldName;
        }

        /// <summary> Returns the port that this <see cref="PortConnection"/> points to </summary>
        private NodePort GetPort()
        {
            if (node == null || string.IsNullOrEmpty(fieldName)) return null;
            return node.GetPort(fieldName);
        }
    }
}