namespace UniGame.UniNodes.NodeSystem.Runtime.Interfaces
{
    using UniGreenModules.UniCore.Runtime.Interfaces;

    public interface INodeCommand : ICommand
    {
        /// <summary>
        /// attach to target node, create all ports or data
        /// </summary>
        /// <param name="targetNode"></param>
        void AttachToNode(IUniNode targetNode);

    }
}