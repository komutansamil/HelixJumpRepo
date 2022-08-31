using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region Values
    [SerializeField] private Text _gameResult_Txt;
    [SerializeField] private Text _totalPoint_Txt;
    [SerializeField] private Text _earnedPoint_Txt;
    [SerializeField] private Button _nextEvent_Button;
    [SerializeField] private GameObject _gameResultPanel_Obj;
    [SerializeField] private GameObject _tapToPlayPanel_Obj;
    [SerializeField] private GameObject[] _levels_Obj;
    [SerializeField] private GameObject ball;
    [SerializeField] private Data data;
    bool _isGameOver = false;
    bool _isLevelCompleted = false;
    bool _isStartTheGame = false;

    int _earnedPoint;
    int _totalPoint;

    [HideInInspector] public Text EarnedPoint_Txt { get { return _earnedPoint_Txt; } set { _earnedPoint_Txt = value; } }
    [HideInInspector] public Text TotalPoint_Txt { get { return _totalPoint_Txt; } set { _totalPoint_Txt = value; } }
    [HideInInspector] public bool IsGameOver { get { return _isGameOver; } set { _isGameOver = value; } }
    [HideInInspector] public bool IsLevelCompleted { get { return _isLevelCompleted; } set { _isLevelCompleted = value; } }
    [HideInInspector] public bool IsStartTheGame { get { return _isStartTheGame; } set { _isStartTheGame = value; } }
    [HideInInspector] public int TotalPoint { get { return _totalPoint; } set { _totalPoint = value; } }
    [HideInInspector] public int EarnedPoint { get { return _earnedPoint; } set { _earnedPoint = value; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _gameResult_Txt.text = "";
        _nextEvent_Button.onClick.AddListener(ReloadTheScene);

        for (int i = 0; i < data.islevels.Length; i++)
        {
            if(data.islevels[i])
            {
                _levels_Obj[i].SetActive(true);
            }
            else
            {
                _levels_Obj[i].SetActive(false);
            }
        }

        PlayerPrefs.GetInt("TotalPoint", TotalPoint);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTheGameStatue();
        TapToPlay();
    }

    void TapToPlay()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _tapToPlayPanel_Obj.SetActive(false);
            _isStartTheGame = true;
        }
        if(_isStartTheGame)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
        }

    }

    void CheckTheGameStatue()
    {
        if (_isLevelCompleted)
        {
            TotalPoint = _totalPoint + _earnedPoint;
            PlayerPrefs.SetInt("TotalPoint", TotalPoint);
            _gameResult_Txt.text = "You Won";
            data.levelCount++;
            data.islevels[data.levelCount] = true;
            _isLevelCompleted = false;
        }
        if (_isGameOver)
        {
            _gameResult_Txt.text = "Game Over";
            _gameResultPanel_Obj.SetActive(true);
        }
    }

    void ReloadTheScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
