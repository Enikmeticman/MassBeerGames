using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

/// <summary>
/// Instantiate a pile as gameobject
/// </summary>
public class PileInstatiator : MonoBehaviour 
{
    /// <summary>
    /// The card prefab used for instantiating
    /// </summary>
    public GameObject PrefabPile = null;

    #region Singleton
    public static PileInstatiator _Instance = null;

    public static PileInstatiator Instance
    {
        get { return _Instance ?? (FindObjectOfType<PileInstatiator>()); }
    }
    #endregion

    /// <summary>
    /// Returns a new deck.
    /// </summary>
    /// <param name="pDeckType">The type of deck we need</param>
    /// <returns></returns>
    public Pile Instatiate(PileType pPile, Vector3 pPosition)
    {
        var obj = (GameObject)Instantiate(PrefabPile, pPosition, Quaternion.identity);
        System.Diagnostics.Debug.Assert(obj != null);

        switch (pPile)
        {
            case PileType.Random:
                return obj.AddComponent<RandomPile>();
            case PileType.Stack:
                return obj.AddComponent<StackPile>();
        }

        System.Diagnostics.Debug.Assert(false);
        return null;
    }
}
