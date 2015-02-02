using System.Collections.Generic;
using System.Linq;
using Assets.GameAssets.Scripts.GamePlay;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class RandomDeck : Deck
{
    #region privates
    /// <summary>
    /// Locks the deck after it is initialized, So that some data can't change anymore.
    /// </summary>
    private bool _Locked = false;

    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private RandomCardContainer _Cards = null;
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
    /// <summary>
    /// Constructor
    /// </summary>
    public RandomDeck()
    {
        DeckId = Deck.DeckInstances;
        ++Deck.DeckInstances;

        _Cards = CardContainer.CreateContainer(this, OrderType.Random) as RandomCardContainer;

        SelectedChanged = OnSelectedChanged; 
        HighLighted += OnHighLighted;
    }

    #region public Functions
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
    /// Gets a card from the deck.
    /// </summary>
    /// <param name="pCardName">Name of the card.</param>
    /// <returns>The card if found.</returns>
    public override Card GetCard(string pCardName)
    {
        return _Cards.GetCard(pCardName);
    }

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    public override bool AddCard(Card pCard)
    {
        if (pCard != null && pCard.DeckId == DeckId)
            return false;

        return _Cards.AddCard(pCard);
    }

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    public bool Insert(Card pCard, int pIncex)
    {
        if (pCard != null && pCard.DeckId == DeckId)
            return false;

        return _Cards.Insert(pCard,pIncex);
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

        if(CardPicker.Instance.Open)
            CardPicker.Instance.ClosePicker();
    }

    private void OnHighLighted()
    {
        VisualHighLight();

        CardPicker.Instance.OpenPicker(_Cards.GetDummyCards());

    }
    #endregion
}

