﻿using UniGame.UniNodes.NodeSystem.Runtime.Core;

namespace UniGame.UniNodes.Nodes.Runtime.SerializableNodes
{
    using System;
    using System.Collections.Generic;
    using NodeSystem.Runtime.Core.Nodes;
    using NodeSystem.Runtime.Extensions;
    using NodeSystem.Runtime.Interfaces;
    using UniCore.Runtime.ProfilerTools;
    using UniModules.UniCore.Runtime.ProfilerTools;
    using UniModules.UniCore.Runtime.Rx.Extensions;
    using UniModules.UniGame.Core.Runtime.Interfaces;
    using UniModules.UniGameFlow.NodeSystem.Runtime.Core.Attributes;
    using UniRx;

    [CreateNodeMenu("Debug/SLog",nodeName = "SLog")]
    [Serializable]
    public class SLogNode : SNode,IMessagePublisher
    {
        private const string logPortName = "log";
        
        public LogMode mode = LogMode.Log;

        public string message = "LogNode";

        private IPortValue logPort;

        protected override void OnExecute()
        {
            PrintLog(GetMessage(), mode);
            logPort.Broadcast(this).
                AddTo(LifeTime);
        }

        protected override void UpdateCommands(List<ILifeTimeCommand> nodeCommands)
        {
            base.UpdateCommands(nodeCommands);
            logPort = this.UpdatePortValue(logPortName, PortIO.Input);
        }

        protected virtual string GetMessage()
        {
            return message;
        }

        public void Publish<T>(T value)
        {
            PrintLog($"{message}: GRAPH:{GraphData.ItemName} : {ItemName} \n\t {value.GetType().Name} : {value}", mode);
        }
        
        private void PrintLog(string messageData, LogMode logMode)
        {
            switch (logMode) {
                case LogMode.Runtime:
                    GameLog.LogRuntime(messageData);
                    break;
                case LogMode.Log:
                    GameLog.Log(messageData);
                    break;
                case LogMode.Warning:
                    GameLog.LogWarning(messageData);
                    break;
                case LogMode.Error:
                    GameLog.LogError(messageData);
                    break;
                case LogMode.Exception:
                    GameLog.LogError(messageData);
                    break;
            }
        }
    }
}
