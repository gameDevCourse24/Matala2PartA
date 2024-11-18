using UnityEngine;
using UnityEngine.InputSystem;

public class Hide : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Toggle the visibility of the object.")]
    InputAction toggleVisibility = new InputAction(type: InputActionType.Button);

    private Renderer objectRenderer; // רכיב ההצגה של האובייקט

    void OnValidate()
    {
        // הגדרת ברירת מחדל ל-InputAction
        if (toggleVisibility.bindings.Count == 0)
            toggleVisibility.AddBinding("<Keyboard>/h"); // ברירת מחדל: מקש H
    }

    void OnEnable()
    {
        // הפעלת הפעולה
        toggleVisibility.Enable();
    }

    void OnDisable()
    {
        // השבתת הפעולה
        toggleVisibility.Disable();
    }

    void Awake()
    {
        // קבלת ה-Renderer של האובייקט
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // בדיקת לחיצה על הכפתור
        if (toggleVisibility.WasPressedThisFrame())
        {
            if (objectRenderer != null)
            {
                // הפיכת מצב ההצגה
                objectRenderer.enabled = !objectRenderer.enabled;
            }
        }
    }
}
