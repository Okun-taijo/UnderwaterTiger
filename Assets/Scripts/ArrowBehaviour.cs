using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private TextMeshProUGUI _alertText;
    [SerializeField] private GameObject _chestPrefab; 
    private GameObject _arrowInstance;
    private GameObject _targetChest; 

    void Start()
    {
        // Находим первый сундук на сцене и делаем его целью
        _targetChest = GameObject.FindGameObjectWithTag("Chest");
    }

    public void PlaceArrow()
    {
        if (_targetChest != null) 
        {
            Transform nearestChest = _targetChest.transform; 
            if (nearestChest != null)
            {
                // Находим направление к целевому сундуку и поворачиваем стрелку
                Vector3 direction = nearestChest.position - _playerTransform.position;
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                Vector3 eulerAngles = targetRotation.eulerAngles;
                eulerAngles.x = 90f;
                eulerAngles.z += 90f;
                _arrowInstance.transform.rotation = Quaternion.Euler(eulerAngles);

                
                Vector3 newPosition = _playerTransform.position;
                newPosition.y = 0.01f;
                newPosition.x -= 0.14f;
                _arrowInstance.transform.position = newPosition;

            }
            else
            {
                _arrowInstance.SetActive(false);
                _alertText.text = "No chests around";
                StartCoroutine(FadeInOutText());
            }
        }
        else
        {
            Debug.Log("DoesntWork");
        }
    }

    public void CreateArrow()
    {
        _arrowInstance = Instantiate(_arrowPrefab, transform.position, Quaternion.identity);
    }

    // Метод для установки новой цели сундука
    public void SetTargetChest(GameObject chestPrefab)
    {
        _targetChest = chestPrefab;
    }

    private IEnumerator FadeInOutText()
    {
        _alertText.gameObject.SetActive(true);
        _alertText.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(3f);
        _alertText.CrossFadeAlpha(0f, 2f, false);
        yield return new WaitForSeconds(2f);
        _alertText.gameObject.SetActive(false);
    }
}