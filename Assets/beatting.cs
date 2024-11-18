using UnityEngine;

public class Beatting : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The maximum size of the object")]
    float maxsize = 10f;
    [SerializeField]
    [Tooltip("The minimum size of the object")]
    float minsize = 1f;
    [SerializeField]
    [Tooltip("Scaling speed")]
    float speed = 1f;
    float size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;
         size = Mathf.Lerp(minsize, maxsize, t);
         transform.localScale = new Vector3(size, size, size);
    }
    
}
