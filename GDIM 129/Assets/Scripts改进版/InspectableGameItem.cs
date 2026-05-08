using UnityEngine;

public class InspectableGameItem : InteractableGameItem{
    public GameObject InspectUIPrefab;

    public override void Interact(GameObject origin = null) {
        throw new System.NotImplementedException();
    }
}
