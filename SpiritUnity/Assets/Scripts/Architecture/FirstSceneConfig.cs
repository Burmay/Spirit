using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "TestScene";

    public override string sceneName => SCENE_NAME;


    // «десь создаютс€ все экземпл€ры классов дл€ конктерной сцены, списком
    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsRoll = new Dictionary<Type, Interactor>();

        this.CreateInteractor<InventoryInteractor>(interactorsRoll);
        this.CreateInteractor<UnitBehaviourInteractor>(interactorsRoll);
        this.CreateInteractor<PathFindingInteractor>(interactorsRoll);
        this.CreateInteractor<GraphsInteractor>(interactorsRoll);

        return interactorsRoll;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesRoll = new Dictionary<Type, Repository>();

        this.CreateRepository<InventoryRepository>(repositoriesRoll);
        this.CreateRepository<UnitBehaviourRepository>(repositoriesRoll);

        return repositoriesRoll;
    }
}
