using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.ecs.factories
{
    abstract class AGameFactory : AFactory
    {
        protected GameContext context;

        protected AGameFactory(GameContext context)
        {
            this.context = context;
        }
    }
}
