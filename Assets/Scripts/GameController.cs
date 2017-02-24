using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Assets.Sources.util;
using System;
using Assets.Sources.ecs.systems.destroy;
using Assets.Sources.ecs.systems.game;
using Assets.Sources.ecs.systems.view;
//using Assets.Sources.ecs.systems.input;
using Assets.Sources.ecs.systems.init;

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
        var initSystems = new Feature("Init Systems");
        var inputSystems = new Feature("Input Systems");
        var gameSystems = new Feature("Game Systems");
        var viewSystems = new Feature("View Systems");
        var destroySystems = new Feature("Destroy Systems");

        initSystems.Add(InitSystem(typeof(InitPlayerSystem), contexts));

        //inputSystems.Add(InitSystem(typeof(InitPlayerSystem), contexts));

        gameSystems.Add(InitSystem(typeof(MoveSystem), contexts));

        viewSystems.Add(InitSystem(typeof(AddViewSystem), contexts));
        viewSystems.Add(InitSystem(typeof(RemoveViewSystem), contexts));
        viewSystems.Add(InitSystem(typeof(UpdatePositionSystem), contexts));

        destroySystems.Add(InitSystem(typeof(DestroySystem), contexts));

        var systems = new Feature(featurestr)
            .Add(initSystems)
            .Add(inputSystems)
            .Add(gameSystems)
            .Add(viewSystems)
            .Add(destroySystems);

        systems.Initialize();

        return systems;
    }

    ISystem InitSystem(Type type, Contexts contexts)
    {
        return CSAssemblyHelper.instantiateType<ISystem>(type, new object[] { contexts });
    }
}
