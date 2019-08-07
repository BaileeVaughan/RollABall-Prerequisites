using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.TestTools;
using NUnit.Framework;

public class TestSuite
{
    private GameObject game;
    private GameManager gameManager;
    private Player player;

    [SetUp]
    public void SetUp()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Game");
        game = Object.Instantiate(prefab);
        gameManager = GameManager.Instance;
        player = game.GetComponentInChildren<Player>();
    }

    [UnityTest]
    public IEnumerator GamePrefabLoaded()
    {
        yield return new WaitForEndOfFrame();
        Assert.NotNull(game, "Game not loaded");
    }

    [UnityTest]
    public IEnumerator ItemCollideWithPlayer()
    {
        GameObject itemPrefab = Resources.Load<GameObject>("Prefabs/Entities/Item");
        GameObject item = Object.Instantiate(itemPrefab, player.transform.position, Quaternion.identity);
        yield return new WaitForFixedUpdate();
        Assert.IsNull(item, "Item not collding with player");
    }

    [UnityTest]
    public IEnumerator ItemCollectedAndScoreAdded()
    {

    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(game);
    }
}
