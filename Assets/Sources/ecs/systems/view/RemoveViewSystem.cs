using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.ecs.systems.view
{
    using System.Collections.Generic;
    using Entitas;
    using UnityEngine;

    public sealed class RemoveViewSystem : ReactiveSystem<GameEntity>
    {

        public RemoveViewSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return new Collector<GameEntity>(
                new IGroup<GameEntity>[] {
                    context.GetGroup(GameMatcher.Destroyed),
                },
                new GroupEvent[] {
                    GroupEvent.Added
                }
            );
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView;
        }


        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                Object.Destroy(e.view.gameObject);
                e.RemoveView();
            }
        }
    }
}