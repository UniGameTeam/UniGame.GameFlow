﻿namespace UniGame.UniNodes.Examples.ContextNodes.SimpleServices.Runtime
{
    using System.Collections;
    using GameFlow.Runtime;
    using UniGreenModules.UniCore.Runtime.DataFlow.Interfaces;
    using UniGreenModules.UniCore.Runtime.Interfaces;
    using UniGreenModules.UniRoutine.Runtime;
    using UniGreenModules.UniRoutine.Runtime.Extension;
    using UniModules.UniGame.Core.Runtime.DataFlow.Interfaces;

    public class SimpleSystem3 : GameService
    {
        
        protected override IContext OnBind(IContext context, ILifeTime lifeTime = null)
        {
            context.Publish(this);
            ReadyDelay(3).Execute();
            return context;
        }

        private IEnumerator ReadyDelay(float delay)
        {
            yield return this.WaitForSeconds(delay);
            isReady.Value = true;
        }
        
    }
}