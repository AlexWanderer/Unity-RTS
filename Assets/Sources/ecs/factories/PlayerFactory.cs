using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Sources.ecs.factories
{
    class PlayerFactory : AGameFactory
    {
        public PlayerFactory(GameContext context) : base(context) { }

        public Entity CreatePlayer()
        {
            var e = this.context.CreateEntity();
            e.AddAsset("Player");
            e.AddPosition(0, 0, 0);
            e.AddMove(0.001f, 0.025f);
            return e;
        }
    }
}
