using UnityEngine;

public abstract class InteractableGameItem : GameItem, IInteractable {
    public FloatUI HoverUI;

    public abstract void Interact(GameObject origin = null);
}
