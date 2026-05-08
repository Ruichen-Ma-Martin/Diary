using UnityEngine;

public class UIManager : Singleton<UIManager> {
    /*
    #region Singleton
    public static UIManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    #endregion
    */

    // TO-DO: Add a stack to manage multiple UIs (e.g., inventory, dialogue, etc.)

    public GameObject CurrentUI { get; private set; } = null;

    public void SwitchUI (GameObject newUI) {
        if (CurrentUI != null) {
            CurrentUI.SetActive(false);
        }
        CurrentUI = newUI;
        if (CurrentUI != null) {
            CurrentUI.SetActive(true);
        }
    }
}
