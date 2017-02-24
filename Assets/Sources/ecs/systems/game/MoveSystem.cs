using System;
using Entitas;

namespace Assets.Sources.ecs.systems.game
{
    class MoveSystem : IExecuteSystem
    {
        readonly IGroup<GameEntity> group;

        public MoveSystem(Contexts contexts)
        {
            this.group = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.Move, GameMatcher.Position));
        }

        public void Execute()
        {
            foreach (var e in group.GetEntities())
            {
                var move = e.move;
                var pos = e.position;
                e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
            }
        }
    }
}
