using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public static class DeckFactory
{
    /// <summary>
    /// Create a new deck 
    /// </summary>
    /// <param name="pCardType">The cards type are the cards the deck needs to contain</param>
    /// <param name="pDeckType">The type of deck we want</param>
    /// <returns></returns>
    public static Deck GreateDeck(DeckCardType pCardType, DeckType pDeckType, Vector3 pPosition)
    {
        switch (pCardType)
        {
            case DeckCardType.Poker:
            {
                return GreatePokerDeck(pDeckType, pPosition);
            }
        }  
 
        System.Diagnostics.Debug.Assert(false,"The card type is not implemented");
        return null;
    }

    /// <summary>
    /// Get a deck to populate later on
    /// </summary>
    /// <param name="pDeckType">The type of deck we want</param>
    /// <returns></returns>
    private static Deck GetDeck(DeckType pDeckType,Vector3 pPosition)
    {
        switch (pDeckType)
        {
            case DeckType.Random:
                return DeckInstatiator.Instance.Instatiate(typeof(RandomDeck), pPosition);
            case DeckType.Ring:
                return DeckInstatiator.Instance.Instatiate(typeof(RingDeck), pPosition);

        }

        System.Diagnostics.Debug.Assert(false, "The deck type is not implemented");
        return null;
    }

    /// <summary>
    /// Create a new poker deck
    /// </summary>
    /// <param name="pDeckType">The type of the deck</param>
    /// <returns></returns>
    private static Deck GreatePokerDeck(DeckType pDeckType, Vector3 pPosition)
    {
        //Get a new deck.
        var deck = GetDeck(pDeckType, pPosition);
        //Name the deck
        deck.name = string.Format("{0}_Poker_{1}",deck.GetType().Name, deck.DeckId);

        //Create the cards we need.
        List<Card> cards = new List<Card>();
        for (int type = 0; type < 4; ++type)
        {

            for (int val = Global.MIN_CARD_VALUE; val <= Global.MAX_CARD_VALUE; ++val)
            {
                var card = CardInstatiator.Instance.Instatiate(pPosition);

                card.Initialize((ColorType) Convert.ToInt32(Mathf.IsPowerOfTwo((type%2))), (CardType) type, deck.DeckId,val);

                card.transform.parent = deck.transform.FindChild("Cards").transform;

                card.gameObject.name = card.CardName;
              
                cards.Add(card);
            }
        }

        //Give the deck a collider
        deck.GetComponent<BoxCollider>().size = cards[0].GetComponent<BoxCollider>().size;

        //Initialize the select
        var select = deck.transform.FindChild("SelectionHolder").transform.FindChild("Selection");
        select.GetComponent<MeshFilter>().sharedMesh = cards[0].transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;
        select.transform.localScale = cards[0].transform.FindChild("SelectionHolder").transform.FindChild("Selection").transform.localScale;
        select.transform.rotation = cards[0].transform.FindChild("SelectionHolder").transform.FindChild("Selection").transform.rotation;
        select.renderer.sharedMaterial = cards[0].transform.FindChild("SelectionHolder").transform.FindChild("Selection").renderer.sharedMaterial;
        select.GetComponent<MeshRenderer>().enabled = false;

        //Initialize th deck with cards
        deck.Initialize(cards.ToArray());
        //Shuffle the cards in the deck
        deck.Shuffle();

        return deck;
    }
}
