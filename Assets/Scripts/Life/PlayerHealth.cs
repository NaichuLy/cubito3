using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] LifeBar lifeBar;
    [SerializeField] public float _playerLife;
    [SerializeField] float _maxPlayerLife;
    [SerializeField] GameObject happyFace;
    [SerializeField] GameObject neutralFace;
    [SerializeField] GameObject deadFace;

    private void Start()
    {
        _playerLife = _maxPlayerLife;
        happyFace.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetDamage(4);
        }
    }
    public void GetDamage(float damage)
    {
        _playerLife -= damage;
        lifeBar.UpdateLifeBar(_maxPlayerLife, _playerLife);
        
        FaceUpdate();

        if (_playerLife <= 0)
        {
            Destroy(gameObject, 0.3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FaceUpdate()
    {
        if (_playerLife >= 60)
        {
            happyFace.SetActive(true);
            neutralFace.SetActive(false);
            deadFace.SetActive(false);
        }
        else if (_playerLife <60 && _playerLife > 30)
        {
            happyFace.SetActive(false);
            neutralFace.SetActive(true);
            deadFace.SetActive(false);
        }
        else
        {
            happyFace.SetActive(false);
            neutralFace.SetActive(false);
            deadFace.SetActive(true);
        }
    }

}
