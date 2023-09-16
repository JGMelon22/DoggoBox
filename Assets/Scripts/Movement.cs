using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private readonly float _playerSpeed = 35F;
    private float _inputHorizontal;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Sair do game
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKey(KeyCode.R))
            Restart();
        
        // Movimentação do player
        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (_inputHorizontal != 0)
        {
            _rigidbody.AddForce(new Vector2(_inputHorizontal * _playerSpeed, 0));
        }
    }

    // Reiniciar jogo
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}