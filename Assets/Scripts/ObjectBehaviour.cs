using UI.Dialogs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private short finalScore;
    private bool _isGameOver;

    // Obtem o presente ou se cair no chão, game over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isGameOver)
        {
            finalScore++; // Incrementa a pontuação a cada caixa capturada
            SpawnObject();
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            _isGameOver = true;

            Helper.Pause();

            ShowConfirmDialog();

            finalScore = 0; // Reseta a pontuação em caso de restart
        }
    }

    // Gera presente em um lugar aleatório 
    public void SpawnObject()
    {
        var random = new Random();
        Instantiate(prefab, new Vector3(random.Next(-10, 10), 3.9F, 0F), Quaternion.identity);
    }
    
    // Menu simples de alerta 
    private void ShowConfirmDialog()
    {
        uDialog.NewDialog()
            .SetColorScheme("Orange Red")
            .SetThemeImageSet(eThemeImageSet.SciFi)
            .SetIcon(eIconType.Warning)
            .SetTitleText("Alerta")
            .SetShowTitleCloseButton(false)
            .SetContentText($"<b>Game Over:</b> Pontuação final: {finalScore}")
            .SetContentText($"")
            .SetDimensions(400, 200)
            .AddButton("Tentar novamente", () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Helper.Resume();
            })
            .SetCloseWhenAnyButtonClicked();
    }
}