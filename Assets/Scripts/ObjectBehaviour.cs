using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private bool _isGameOver;

    // Obtem o presente ou se cair no chão, game over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isGameOver)
        {
            SpawnObject();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            _isGameOver = true;
            EditorUtility.DisplayDialog("Alerta", "Game over! Tecle \"Esc\" para sair ou \"R\" para recomeçar", "Ok");
            Debug.Log("GAME OVER!");
        }
    }

    // Gera presente em um lugar aleatório 
    public void SpawnObject()
    {
        var random = new Random();
        Instantiate(prefab, new Vector3(random.Next(-10, 10), 3.9F, 0F), Quaternion.identity);
    }
}