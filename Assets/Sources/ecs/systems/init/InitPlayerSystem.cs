using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.ecs.systems.init
{
    class InitPlayerSystem : IInitializeSystem, InitSystemBase
    {
        GameContext context;

        public InitPlayerSystem(Contexts contexts)
        {
            this.context = contexts.game;
        }

        public void Initialize()
        {
            var e = context.CreateEntity();
            e.AddAsset("Player");
            e.AddPosition(0, 0, 0);
            e.AddMove(0.001f, 0.025f);
        }
    }
}
