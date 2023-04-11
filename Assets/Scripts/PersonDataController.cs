using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonDataController : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] TextMeshProUGUI _ageText;

    private WebService<Person> _webService;
    private string _webLink = "https://drive.google.com/uc?export=download&id=17zfhbD1Bg5PfzjyMVT-eJXwpUtVyLJsS";
    private void Awake()
    {
        _webService = new WebService<Person>();

        _button.onClick.AddListener(LoadDataForPerson);
    }

    private async void LoadDataForPerson()
    {
        var personData = await _webService.GetDataByLinc(_webLink);

        if (personData != null)
        {
            SetDataToPerson(personData.Name, personData.Age);
        }
    }

    private void SetDataToPerson(string name, int age)
    {
        _nameText.text = name;
        _ageText.text = age.ToString();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(LoadDataForPerson);

    }
}
