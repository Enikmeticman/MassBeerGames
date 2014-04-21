using System.Collections;
using System.Collections.Generic;

public interface IDeck
{
    #region Properties
    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    int DeckId
    {
        get;
    }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    int Size
    {
        get;
    }
    #endregion

    #region public Functions

    /// <summary>
    /// Initializes the specified deck.
    /// </summary>
    /// <param name="pCards">The p cards.</param>
    /// <returns></returns>
    InitializeSuccess Initialize(Card[] pCards);

    /// <summary>
    /// Gets a card from the deck.
    /// </summary>
    /// <param name="pCardName">Name of the card.</param>
    /// <returns>The card if found.</returns>
    Card GetCard(string pCardName);

    /// <summary>
    /// Add a card. 
    /// </summary>
    /// <param name="pCard">The card that needs to be added.</param>
    /// <param name="pIncex">The index where the new card needs to be.</param>
    /// <returns>true if succeeded.</returns>
    bool AddCard(Card pCard, int pIncex);

    /// <summary>
    /// Shuffles the cards in the deck;
    /// </summary>
    void Shuffle();

    #endregion
}

/// <summary>
/// Indexer the navigate the card in a deck.
/// </summary>
public class CardIndex
{
    public int Index
    {
        get;
        private set;
    }

    public Card ValueCard
    {
        get;
        private set;
    }

    public CardIndex(int pIndex, Card pValueCard)
    {
        Index = pIndex;
        ValueCard = pValueCard;
    }
}