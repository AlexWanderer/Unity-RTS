using UnityEngine;
using Entitas;

namespace Assets.Sources.ecs.systems.input
{
    class InputSystem : IExecuteSystem
    {
        InputContext context;

        public InputSystem(Contexts contexts)
        {
            this.context = contexts.input;
        }

        public void Execute()
        {
            //context.isAccelerating =
            //Input.GetButton("Fire1") ||
            //Input.GetAxisRaw("Vertical") > 0;
        }
    }
}
