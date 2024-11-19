using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [Tooltip("Length of the rope, in meters")]
    public float length = 2f; 
    [Tooltip("Gravity acceleration, in meters per second squared")]
    public float gravity = 9.81f; 
    [Tooltip("Damping coefficient (0 = high friction, 1 = no friction)")]
    [Range(0f, 1f)] public float damping = 0.98f; 
    [Tooltip("Mass of the pendulum, in kilograms")]
    public float mass = 10f; 

    [Header("Initial Conditions")]
    [Tooltip("Initial angle, in degrees")]
    [Range(-90f,90f)]public float initialAngle = 90f; // Initial angel in degrees

    private float angle; // Current angle
    private float angularVelocity; // מהירות זוויתית
    private float angularAcceleration; // תאוצה זוויתית

    void Start()
    {
        // Converting initial angle to Radians
        angle = initialAngle * Mathf.Deg2Rad;
    }

    void Update()
    {
        // חישוב התאוצה הזוויתית לפי חוקי הפיזיקה של מטוטלת
        angularAcceleration = -(gravity / length) * Mathf.Sin(angle);

        // עדכון מהירות וזווית
        angularVelocity += angularAcceleration * Time.deltaTime;

        // הפחתת מהירות בשל חיכוך, חיכוך פחות אגרסיבי
        float effectiveDamping = Mathf.Pow(damping, Time.deltaTime / Mathf.Max(mass, 0.01f));
        // angularVelocity *= Mathf.Pow(damping, Time.deltaTime);
         angularVelocity *= effectiveDamping;

        angle += angularVelocity * Time.deltaTime;

        // עדכון מיקום המטוטלת
        UpdatePendulumPosition();
    }

    private void UpdatePendulumPosition()
    {
        // חישוב מיקום המטוטלת על בסיס הזווית
        float x = length * Mathf.Sin(angle);
        float y = -length * Mathf.Cos(angle);

        // הזזת האובייקט למיקום החדש
        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}
