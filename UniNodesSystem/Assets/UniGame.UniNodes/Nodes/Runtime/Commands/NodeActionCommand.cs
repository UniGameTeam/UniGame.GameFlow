﻿namespace UniGame.UniNodes.Nodes.Runtime.Commands
{
    using System;
    using NodeSystem.Runtime.Core;
    using NodeSystem.Runtime.Core.Commands;
    using NodeSystem.Runtime.Extensions;
    using NodeSystem.Runtime.Interfaces;
    using UniGreenModules.UniCore.Runtime.DataFlow.Interfaces;
    using UniGreenModules.UniCore.Runtime.Interfaces;

    [Serializable]
    public class NodeActionCommand<T> : ILifeTimeCommand
    {
        private PortActionCommand<T> portAction;

        public NodeActionCommand(
            Action<T> action, 
            IUniNode node, 
            string name, 
            PortIO direction = PortIO.Input)
        {
            var portInfo = node.UpdatePortValue(name, direction);
            portAction = new PortActionCommand<T>(action,portInfo);
        }
        
        public void Execute(ILifeTime lifeTime)
        {
            portAction.Execute(lifeTime);
        }
    }
}
