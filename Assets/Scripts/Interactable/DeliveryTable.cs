﻿using System.Collections;
using UnityEngine;

public class DeliveryTable : Interactable
{
    public SpriteRenderer itemImage;

    public Item item = null;

    private void Start()
    {
        itemImage.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
    }

    public override void Interact(Player player)
    {
        if (player.activeItem == null) return;
        if (player.activeItem.currentState != Item.State.Done) return;

        if (item == null)
        {
            PutDown(player);
        }
    }

    private void PutDown(Player player)
    {
        item = player.activeItem;
        OrderManager.RemoveFinishedOrder(item.client.orderCount);
        player.activeItem = null;
        itemImage.sprite = item.image;
        StartCoroutine(DeliverTargetCoroutine());
    }

    IEnumerator DeliverTargetCoroutine()
    {
        yield return new WaitForSeconds(2);
        item = null;
        itemImage.sprite = null;
    }
}
