using System;
using System.Collections.Generic;
using Assets.GameAssets.Scripts.GamePlay;
using Assets.GameAssets.Scripts.GamePlay.Cards;
using UnityEngine;
using System.Collections;

public class CardPicker : MonoBehaviour
{
    #region Singleton
    public static CardPicker _Instance = null;

    public static CardPicker Instance
    {
        get { return _Instance ?? (FindObjectOfType<CardPicker>()); }
    }
    #endregion

    public Animator _Animator = null;
    public GameObject test = null;
    public bool Open { get; private set; }

    private List<GameObject> _ViewCards = new List<GameObject>(); 

    void Awake()
    {
        Open = false;
        _Animator = transform.GetChild(0).GetComponent<Animator>();

    }

    public void OpenPicker(CardDummy[] pCards)
    {
        _Animator.SetBool("OpenPicker",true);

        StartCoroutine("LayoutCards", pCards);
        Open = true;
    }

    public void ClosePicker()
    {
        _Animator.SetBool("OpenPicker", false);

        StopCoroutine("LayoutCards");

        _ViewCards.ForEach(DestroyObject);
        _ViewCards.Clear();

        Open = false;
    }

    private IEnumerator LayoutCards(object pCards)
    {
        var cards = (CardDummy[])pCards;

        float angleInc = 360f /cards.Length;
        float angle = 0f;
        float translateInc = cards.Length *1.2f;

        yield return new WaitForSeconds(0.5f);

        foreach (var card in cards)
        {
            var position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
            var obj = Instantiate(PrefabContainer.Instance.GetPrefab(PrefabContainer.Prefabs.CardDummy), position, Quaternion.identity) as GameObject;

            obj.GetComponent<CardDummyView>().SetDummy(card);

            obj.transform.Rotate(Vector3.forward,-angle);
            obj.transform.Translate(Vector3.up * translateInc);

            angle += angleInc;
            _ViewCards.Add(obj);

            yield return new WaitForEndOfFrame();
        }
    }
}
