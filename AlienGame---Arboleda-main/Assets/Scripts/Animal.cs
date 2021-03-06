using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int vida;
    public bool lento = false;

    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        

        if(transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movingRight = true;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Disparo") )
        {

               Da?o();
                if (gm.lento == true)
                {
                    vida = 1;
                    Destroy(this.gameObject);
                    gm.ReducirNumEnemigos();
                }
                else if (vida < 1)
                    {
                     Destroy(this.gameObject);
                     gm.ReducirNumEnemigos();
                    }
                
        }
        else if(collision.gameObject.CompareTag("DisparoRafaga"))
        {
            Da?o();
            if(gm.lento == true)
            {
                vida = 1;
                Destroy(this.gameObject);
                gm.ReducirNumEnemigos();
            }
            else if (vida < 1)
            {
                Destroy(this.gameObject);
                gm.ReducirNumEnemigos();
            }
        }
    }
    void Da?o()
    {
        vida = vida - 1;
    }

}