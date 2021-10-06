using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_script : MonoBehaviour
{
    public float speed = 5f;

    private float input;

    public float pointsEstudio = 0f;
    public float pointsFelicidad = 0f;
    public float pointsEnergia = 0f;
    public float eventTimer = 0f;
    private bool DebuffInput;
    public bool eventoActivo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(DebuffInput)
        {

            input = -input;
        }
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * input * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Estudio"))
        {
            pointsEstudio++;
        }
        if (collision.gameObject.CompareTag("Felicidad"))
        {
            pointsFelicidad++;
        }
        if (collision.gameObject.CompareTag("Energia"))
        {
            pointsEnergia++;
        }
        if (collision.gameObject.CompareTag("Evento")&&!eventoActivo)
        {
            int num = (int) Random.Range(1 , 6);
            switch(num)
            {
                case 1:
                    StartCoroutine(buff());
                    break;

                case 2:
                    StartCoroutine(debuff());
                    break;

                case 3:
                    StartCoroutine(scaleDebuff());
                    break;
                case 4:
                    StartCoroutine(scaleBuff());
                    break;
                case 5:
                    StartCoroutine(debuffInput());
                    break;

                default:
                break;
            }

            

        }


    }


    IEnumerator buff()
    {
        speed = speed * 2;
        eventoActivo = true;
        yield return new WaitForSeconds(7);
        speed = speed / 2;
        eventoActivo = false;
        Debug.Log("Buff terminado");
    }

    IEnumerator scaleDebuff()
    {
        transform.localScale = new Vector3(3,1,1);
            eventoActivo = true;
        yield return new WaitForSeconds(7);
        transform.localScale = new Vector3(5, 1, 1);

        eventoActivo = false;
        Debug.Log("Debuff terminado");
    }

    IEnumerator scaleBuff()
    {
        transform.localScale = new Vector3(7, 1, 1);
        eventoActivo = true;
        yield return new WaitForSeconds(7);
        transform.localScale = new Vector3(5, 1, 1);

        eventoActivo = false;
        Debug.Log("Buff terminado");
    }

    IEnumerator debuff()
    {
        speed = speed / 3;
        eventoActivo = true;

        yield return new WaitForSeconds(7);
        speed = speed * 3;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }

    IEnumerator debuffInput()
    {
        DebuffInput = true;
        eventoActivo = true;

        yield return new WaitForSeconds(7);
        DebuffInput = false;
        eventoActivo = false;

        Debug.Log("Debuff terminado");
    }
    public float getPuntosFamilia()
}
