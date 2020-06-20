﻿namespace UniGame.UniNodes.Nodes.Runtime.Common
{
    using System.Collections.Generic;
    using NodeSystem.Runtime.Core;
    using NodeSystem.Runtime.Core.Commands;
    using NodeSystem.Runtime.Core.Interfaces;
    using UniGreenModules.UniCore.Runtime.Interfaces;
    using UniModules.UniGameFlow.NodeSystem.Runtime.Core.Attributes;

    [CreateNodeMenu("Common/InOutPorts")]
    public class InOutPortsNode : UniNode
    {
        protected List<IPortPair> inOutPorts = new List<IPortPair>();
    
        #region inspector data
    
        public List<string> portNames = new List<string>(){"data"};

        public bool bindPorts = false;
        
        #endregion

        protected override void UpdateCommands(List<ILifeTimeCommand> nodeCommands)
        {
            base.UpdateCommands(nodeCommands);

            for (int i = 0; i < portNames.Count; i++) {
                var portName = portNames[i];
                var portCommand = new ConnectedFormatedPairCommand(this,portName,bindPorts);
                nodeCommands.Add(portCommand);
                inOutPorts.Add(portCommand);
            }
        }
    }
}
