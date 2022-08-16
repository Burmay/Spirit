using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "SampleScene";

    public override string sceneName => SCENE_NAME;


    // ����� ��������� ��� ���������� ������� ��� ���������� �����, �������
    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsRoll = new Dictionary<Type, Interactor>();

        this.CreateInteractor<InventoryInteractor>(interactorsRoll);

        return interactorsRoll;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesRoll = new Dictionary<Type, Repository>();

        this.CreateRepository<InventoryRepository>(repositoriesRoll);

        return repositoriesRoll;
    }
}
