using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class StackPile : Pile
{
    #region privates
    /// <summary>
    /// A List containing all the cards in the deck.
    /// </summary>
    private Queue<Card> _Cards = new Queue<Card>();
    #endregion

    #region Properties
    /// <summary>
    /// The id of the deck. /property/
    /// </summary>
    public new int PileId
    {
        get;
        private set;
    }

    /// <summary>
    /// The current deck size. /property/
    /// </summary>
    public new int Size
    {
        get
        {
            return _Cards.Count;
        }
    }
    #endregion

    #region public Functions

    public StackPile()
    {
        PileId = Pile.PileInstances;
        ++Pile.PileInstances;

        SelectedChanged = OnSelectedChanged;
        HighLighted += OnHighLighted;
    }

    public override void Initialize(VisableCardStyle pShowMode, PickStyle pPickMode)
    {
        VisableCardStyle = pShowMode;
        PickStyle = pPickMode;
    }

    public override Card GetCard(string pCardName)
    {
        if (_Cards.Count > 0)
            return _Cards.Dequeue();
        return null;
    }

    public override bool AddCard(Card pCard, int pIncex)
    {
        if (_Cards.Count > 0)
            _Cards.Peek().Visable = false;

        switch (VisableCardStyle)
        {
            case VisableCardStyle.All:
            case VisableCardStyle.Top:
            {
                pCard.Visable = true;
                
            }
            break;
        }

        pCard.transform.rotation = this.transform.rotation;

        _Cards.Enqueue(pCard);
        return true;
    }

    public override void Klicked()
    {
        throw new System.NotImplementedException();
    }

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
    #endregion
}
