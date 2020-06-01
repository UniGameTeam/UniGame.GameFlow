﻿namespace UniModules.UniGameFlow.Nodes.Runtime.Scene
{
    using global::UniGame.UniNodes.Nodes.Runtime.Common;
    using global::UniGame.UniNodes.NodeSystem.Runtime.Core;
    using UnityEngine;

    [CreateNodeMenu("Scene/SceneReference")]
    public class SceneReferenceNode<T> : ContextNode where T : Object
    {
        [SerializeField]
        private T target;
        protected T Target => target;
    }
}
