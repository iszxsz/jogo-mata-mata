using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform target; // Objeto a ser seguido
    public float speed = 5f; // Velocidade de movimento do objeto que segue

    private void Update()
    {
        // Verifica se o alvo existe
        if (target != null)
        {
            // Calcula a direção do movimento
            Vector3 direction = target.position - transform.position;

            // Normaliza a direção para manter uma velocidade constante
            direction.Normalize();

            // Move o objeto na direção do alvo com a velocidade definida
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}