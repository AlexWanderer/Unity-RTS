﻿using System.Collections.Generic;
using Entitas;

namespace Assets.Sources.ecs.systems.destroy
{
    public sealed class DestroySystem : ReactiveSystem<GameEntity>, DestroySystemBase
    {
        readonly GameContext context;

        public DestroySystem(Contexts contexts) : base(contexts.game)
        {
            context = contexts.game;
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                context.DestroyEntity(e);
            }
        }
    }
}
