using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PrefabContainer : MonoBehaviour 
{
    public enum Prefabs
    {
        Card,
        Pile,
        CardDummy
    }

    public GameObject CardPrefab = null;
    public GameObject PilePrefab = null;
    public GameObject CardDummyPrefab = null;

    #region Singleton
    public static PrefabContainer _Instance = null;

    public static PrefabContainer Instance
    {
        get { return _Instance ?? (FindObjectOfType<PrefabContainer>()); }
    }
    #endregion

    public GameObject GetPrefab(Prefabs pPrefabs)
    {
        switch (pPrefabs)
        {
            case Prefabs.Card:
                return CardPrefab;
            case Prefabs.Pile:
                return PilePrefab;
            case Prefabs.CardDummy:
                return CardDummyPrefab;
        }

        return null;
        System.Diagnostics.Debug.Assert(false, "The prefab does not exist");
    }
}
