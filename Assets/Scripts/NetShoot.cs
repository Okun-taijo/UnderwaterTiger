using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetShoot : MonoBehaviour
{
    [SerializeField] private Camera _crosshairCamera;
    [SerializeField] private GameObject _netPrefab;
    [SerializeField] private Transform _netStartPoint;
    [SerializeField] private float _netSpeed;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _fishParticlePrefab;
    [SerializeField] private VictoryManager _victoryManager;
    [SerializeField] private int _maxNets;
    [SerializeField] private GameObject _losePanel;

    public int _availableNets;
    private bool _isCooldown = false;
    void Start()
    {
        _availableNets = _maxNets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowNet()
    {
        if (!_isCooldown)
        {
            RaycastHit hit;
            if (Physics.Raycast(_crosshairCamera.transform.position, _crosshairCamera.transform.forward, out hit, _range))
            {
                if (hit.collider.CompareTag("Fish"))
                {
                    GameObject net = Instantiate(_netPrefab, hit.point, _netPrefab.transform.rotation);
                    GameObject fishParticle = Instantiate(_fishParticlePrefab, hit.collider.transform.position, Quaternion.identity);
                    hit.collider.GetComponent<FishMovement>().SetSpeed(0f);
                    FishParametrs fish = hit.collider.GetComponent<FishParametrs>();
                    fish.CatchFish();
                    Destroy(hit.collider.gameObject, 0.5f);
                    Destroy(net, 0.5f);
                    Destroy(fishParticle, 1.0f);
                    _victoryManager.CatchFish(fish.fishName);
                    _availableNets--;
                    if (_availableNets == 0)
                    {
                        OnEndedNets();
                    }
                }
                if (hit.collider.CompareTag("Chest") || (hit.collider.CompareTag("Junk")))
                {
                    GameObject net = Instantiate(_netPrefab, hit.point, _netPrefab.transform.rotation);
                    GameObject fishParticle = Instantiate(_fishParticlePrefab, hit.collider.transform.position, Quaternion.identity);
                    FishParametrs fish = hit.collider.GetComponent<FishParametrs>();
                    fish.CatchFish();
                    Destroy(hit.collider.gameObject, 0.5f);
                    Destroy(net, 0.5f);
                    Destroy(fishParticle, 1.0f);
                    _availableNets--;
                    if (_availableNets == 0)
                    {
                        OnEndedNets();
                    }
                }


            }
        }

    }
    public void OnEndedNets()
    {
        _losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public int GetNetCount()
    {
        return _availableNets;
    }
    public IEnumerator Cooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(3f);
        _isCooldown = false;
      
    }
}
