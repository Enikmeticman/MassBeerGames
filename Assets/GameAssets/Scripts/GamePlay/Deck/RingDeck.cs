using System.Collections.Generic;
using System.Diagnostics;
using Assets.GameAssets.Scripts.GamePlay;
using UnityEngine;
using Random = System.Random;

public class RingDeck : Deck
{
    #region privates
    /// <summary>
    /// Locks the deck after it is initialized, So that some data can't change anymore.
    /// </summary>
    private bool _Locked = false;

    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private OrderedCardContainer _Cards = null;
    #endregion

    #region Properties
    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public override int Size
    {
        get
        {
            return _Cards.Count;
        }
    }
    #endregion

    #region public Functions
    /// <summary>
    /// Constructor
    /// </summary>
    public RingDeck()
    {
        DeckId = Deck.DeckInstances;
        ++Deck.DeckInstances;

        _Cards = CardContainer.CreateContainer(this, OrderType.Orderd) as OrderedCardContainer;
        SelectedChanged = OnSelectedChanged;
        HighLighted += OnHighLighted;
    }
    /// <summary>
    /// Initializes the specified deck.
    /// </summary>
    /// <param name="pCards">The p cards.</param>
    /// <returns></returns>
    public override InitializeSuccess Initialize(Card[] pCards)
    {
        if (_Locked) return InitializeSuccess.AlreadyInitialized;

        foreach (Card card in pCards)
        {
            _Cards.AddCard(card);
        }

        return InitializeSuccess.Succeed;
    }

    /// <summary>
    /// Gets the next card from the deck.
    /// </summary>
    /// <param name="pCardName">Not used int a ring deck.</param>
    /// <returns>A Card null if no cards are left</returns>
    public override Card GetCard(string pCardName)
    {

        return _Cards.GetCard(pCardName);
    }

    public Card Top()
    {
        return _Cards.Peek();
    }

    /// <summary>
    /// Adds a new card to the end of the deck.
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">Not used in a ring decj.</param>
    /// <returns>true if succeeded.</returns>
    public override bool AddCard(Card pCard)
    {
        if (pCard != null && pCard.DeckId == DeckId)
            return false;

        return _Cards.AddCard(pCard);
    }

    public override void Shuffle()
    {
        _Cards.Shuffle();
    }

    public override void Klicked()
    {

    }
    #endregion

    #region private Functions
    private void OnSelectedChanged(bool pSelected)
    {
        VisualSelect(pSelected);
    }

    private void OnHighLighted()
    {
        VisualHighLight();
    }
    #endregion
}
