using System;
using System.Collections.Generic;
using UnityEngine;

public static class PileFactory
{
    /// <summary>
    /// Create a new deck 
    /// </summary>
    /// <param name="pCardType">The cards type are the cards the deck needs to contain</param>
    /// <param name="pDeckType">The type of deck we want</param>
    /// <returns></returns>
    public static Pile GreatePile(PileType pPile, VisableCardStyle pShowMode, PickStyle pPickMode, Vector3 pPosition)
    {
        //Get a new pile.
        var pile = GetPile(pPile, pPosition);
        pile.Initialize(pShowMode, pPickMode);

        //Name the pile
        pile.name = string.Format("{0}_{1}", pile.GetType().Name, pile.PileId);


        return pile;

    }

    /// <summary>
    /// Get a pile
    /// </summary>
    /// <param name="pPile">The type of pile</param>
    /// <param name="pPosition">The position of the pile</param>
    /// <returns></returns>
    private static Pile GetPile(PileType pPile, Vector3 pPosition)
    {
        return PileInstatiator.Instance.Instatiate(pPile, pPosition);
    }
}

