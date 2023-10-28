using UI.Dialogs;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class FirecrackerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private bool _isGameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_isGameOver)
        {
            SpawnFirecracker();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            _isGameOver = true;
            Destroy(gameObject);

            Helper.Pause();

            ShowSimpleDialog();
        }
    }

    public void SpawnFirecracker()
    {
        var random = new Random();
        Instantiate(prefab, new Vector3(random.Next(-10, 10), 3.9F, 0F), Quaternion.identity);
    }
    
    // Dialog box simples 
    private void ShowSimpleDialog()
    {
        uDialog.NewDialog()
            .SetTitleText("<b>Game Over</b>")
            .SetContentText($"Você perdeu todos os presentes :(")
            .SetDimensions(400, 200)
            .AddButton("Tentar novamente", () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Helper.Resume();
            })
            .SetCloseWhenAnyButtonClicked();
    }
}