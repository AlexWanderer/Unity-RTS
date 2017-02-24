using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.ecs.systems.init
{
    class InitPlayerSystem : IInitializeSystem
    {
        GameContext context;

        public InitPlayerSystem(Contexts contexts)
        {
            this.context = contexts.game;
        }

        public void Initialize()
        {
            var e = context.CreateEntity();
            (new factories.PlayerFactory(this.context)).CreatePlayer();
        }
    }
}
