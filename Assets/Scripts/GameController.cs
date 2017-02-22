using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Assets.Sources.util;

public class GameController : MonoBehaviour
{
    Systems systems;
    bool ready;

    // Use this for initialization
    void Start()
    {
        this.ready = false;
        var contexts = Contexts.sharedInstance;
        contexts.SetAllContexts();

        this.systems = InitSystems("Systems", contexts);
        this.ready = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.ready)
        {
            this.systems.Execute();
        }
    }

    Systems InitSystems(string featurestr, Contexts contexts)
    {
        var systems = new Feature(featurestr)
            .Add(InitSystemsGroup<Assets.Sources.ecs.systems.init.InitSystemBase>("Init Systems", contexts))
            .Add(InitSystemsGroup<Assets.Sources.ecs.systems.input.InputSystemBase>("Input Systems", contexts))
            .Add(InitSystemsGroup<Assets.Sources.ecs.systems.game.GameSystemBase>("Game Systems", contexts))
            .Add(InitSystemsGroup<Assets.Sources.ecs.systems.view.ViewSystemBase>("View Systems", contexts))
            .Add(InitSystemsGroup<Assets.Sources.ecs.systems.destroy.DestroySystemBase>("Destroy Systems", contexts));

        systems.Initialize();

        return systems;
    }

    // Initialise all systems that derive from this particular type
    Systems InitSystemsGroup<T>(string featurestr, Contexts contexts) where T : class
    {
        var feature = new Feature(featurestr);
        var listOfDerivedClasses = CSAssemblyHelper.getSubtypes<T>();

        foreach (var type in listOfDerivedClasses)
        {
            var systemInstance =
                CSAssemblyHelper.instantiateType<ISystem>(type, new object[] { contexts });
            feature.Add(systemInstance);
        }

        return feature;
    }
}
