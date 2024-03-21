using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiScript : MonoBehaviour
{
    public Transform objetivo; 

    public float velocidad = 3f; 
    public int health=14;
    public bool seguir=false;
    [SerializeField] PlayerScript playerController;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerScript>();    
    }
    void Update()
    {
       
        if (objetivo != null && seguir)
        {
            Seguir();
        }
        if (health < 1)
        {
            playerController.MatarZombi();
            Destroy(gameObject);
            
            
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            
        }
    }

    private void Seguir() {
      
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        
        Quaternion rotacionDeseada = Quaternion.LookRotation(new Vector3(direccion.x, 0f, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * 5f);

       
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

}
