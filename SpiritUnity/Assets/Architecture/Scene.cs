using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    // Хранение всех ссылок
    private InteractorsBase interactorsBase;
    private RepositoriesBase repositoriesBase;
    private SceneConfig sceneConfig;

    public Scene(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
        this.interactorsBase = new InteractorsBase(sceneConfig);
        this.repositoriesBase = new RepositoriesBase(sceneConfig);
    }

    public Coroutine InitializeAsync()
    {
        return Coroutines.StartRoutine(this.InitializeRoutine());
    }

    public IEnumerator InitializeRoutine()
    {
        interactorsBase.CreateAllInteractors();
        repositoriesBase.CreateAllRepositories();
        yield return null;

        Debug.Log(" 1 Yes");
        interactorsBase.SendOnCreateToAllInteractors();
        repositoriesBase.SendOnCreateToAllRepository();
        yield return null;
        Debug.Log(" 2 Yes");
        interactorsBase.InitializeAllInteractors();
        repositoriesBase.InitializeAllRepository();
        yield return null;
        Debug.Log(" 3 Yes");
        interactorsBase.SendOnStartToAllInteractors();
        Debug.Log(" 4.1 Yes");
        repositoriesBase.SendOnStartAllRepository();
        Debug.Log(" 4 Yes");

        Debug.Log($"All Create, <OnCreate> Start, <Init> Start, <OnStart> Start");
    }

    public T GetRepository<T>() where T : Repository
    {
        return this.repositoriesBase.GetRepository<T>();
    }

    public T GetInteractor<T>() where T : Interactor
    {
        return this.interactorsBase.GetInteractor<T>();
    }
}
