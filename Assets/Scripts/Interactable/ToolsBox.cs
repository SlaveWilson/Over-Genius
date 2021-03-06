﻿using UnityEngine;

public class ToolsBox : Interactable
{
    public Sprite toolImage = null;
    public Item toolItem;

    [Header("Item Dialog")]
    [SerializeField] private IconBox iconBox = null;

    public override void Interact(Player player)
    {
        if (player.activeItem == null) player.activeItem = toolItem;
    }

    public override void OnTouch()
    {
        base.OnTouch();
        iconBox.SetIcon(toolImage);
    }

    public override void OnTouchLeave()
    {
        base.OnTouchLeave();
        iconBox.Close();
    }
}
