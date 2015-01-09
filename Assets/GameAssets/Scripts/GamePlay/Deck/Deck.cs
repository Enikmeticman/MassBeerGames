using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : Selectable
{
    #region Properties
    /// <summary>
    /// Static deck instance
    /// </summary>
    protected static int DeckInstances = 0;

    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    public int DeckId{get; protected set; }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public abstract int Size { get;}
    #endregion

    #region public Functions

    /// <summary>
    /// Initializes the specified deck.
    /// </summary>
    /// <param name="pCards">The p cards.</param>
    /// <returns></returns>
    public abstract InitializeSuccess Initialize(Card[] pCards);

    /// <summary>
    /// Gets a card from the deck.
    /// </summary>
    /// <param name="pCardName">Name of the card.</param>
    /// <returns>The card if found.</returns>
    public abstract Card GetCard(string pCardName);

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    public abstract bool AddCard(Card pCard, int pIncex);

    /// <summary>
    /// Shuffles the cards in the deck;
    /// </summary>
    public abstract void Shuffle();

    /// <summary>
    /// Triggers when we click the card.
    /// </summary>
    public abstract void Klicked();

    /// <summary>
    /// Visualy select the deck
    /// </summary>
    protected void VisualSelect(bool pSelected)
    {
        transform.FindChild("SelectionHolder").FindChild("Selection").renderer.enabled = pSelected;
        StopCoroutine("GlowEffect");
        transform.FindChild("SelectionHolder").localScale = Vector3.one;
    }

    /// <summary>
    /// Visualy highlight the deck
    /// </summary>
    protected void VisualHighLight()
    {
        StartCoroutine("GlowEffect");

    }

    IEnumerator GlowEffect()
    {
        {
            var select = transform.FindChild("SelectionHolder");
            bool expand = true;

            float expandValue;

            while (true)
            {
                expandValue = (expand) ? 1.08f : 1;

                var res = Vector3.Lerp(select.transform.localScale, new Vector3(expandValue, expandValue, expandValue), 0.15f);

                decimal x1 = Decimal.Round(new decimal(expandValue), 3);
                decimal x2 = Decimal.Round(new decimal(res.x), 3);


                if (x1 == x2)
                    expand = !expand;

                select.transform.localScale = res;

                yield return new WaitForEndOfFrame();
            }
        }
    }
    #endregion
}

/// <summary>
/// Indexer the navigate the card in a deck.
/// </summary>
public class CardIndex
{
    /// <summary>
    /// Index of the card.
    /// </summary>
    public int Index
    {
        get;
        private set;
    }

    /// <summary>
    /// Value of the card.
    /// </summary>
    public Card ValueCard
    {
        get;
        private set;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="pIndex">Card index</param>
    /// <param name="pValueCard">Card value</param>
    public CardIndex(int pIndex, Card pValueCard)
    {
        Index = pIndex;
        ValueCard = pValueCard;
    }
}