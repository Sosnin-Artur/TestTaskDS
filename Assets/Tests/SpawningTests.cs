using System.Collections;
using Animals.Components;
using Animals.Spawner.Model;
using Animals.Spawner.Presenter;
using Animals.Spawner.View;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class SpawningTests
{
    [Test]
    public void SpawningTestsSimplePasses()
    {
        var model = Substitute.For<ISpawnerData>();
        var view = Substitute.For<ISpawnerView>();

        var spawned = new System.Collections.ObjectModel.ObservableCollection<Animals.Interfaces.IDespawnable>();
        var despawned = new System.Collections.ObjectModel.ObservableCollection<Animals.Interfaces.IDespawnable>();
        model.SpawnedComponents.Returns(spawned);
        model.DespawnedComponents.Returns(despawned);
        model.SpawnRadious.Returns(1f);

        var go = new GameObject("test-animal");
        var realAnimal = go.AddComponent<Animals.Components.AnimalComponent>();

        var factory = Substitute.For<Animals.Components.AnimalComponent.Factory>();
        factory.Create(Arg.Any<UnityEngine.Vector3>()).Returns(realAnimal);

        var spawnerPresenter = new SpawnerPresenter(model, view, factory);

        spawnerPresenter.Spawn();

        Assert.AreEqual(1, model.SpawnedComponents.Count);

        UnityEngine.Object.DestroyImmediate(go);
    }

}
