using UnityEngine;



public class WindowBehaviour : MonoBehaviour
{
    [SerializeField] private bool onFire;
    [SerializeField] private float timeOnFire;
    [SerializeField] public bool isPet;
    [SerializeField] private bool isHuman;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider other)
    {
       string name = "Model";
       Transform childTransform = transform.Find(name);

        if(childTransform != null)
        {
            SpriteRenderer sr = childTransform.gameObject.GetComponent<SpriteRenderer>();

            if(sr != null )
            {
                sr.material.color = Color.red;
            }
        }
    }

    void OnTriggerStay2D(Collider other)
    {

    }
    void OnTriggerExit2D(Collider other)
    {

    }
}
