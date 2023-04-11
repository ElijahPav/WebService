using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class WebService<T>
{
    public async UniTask<T> GetDataByLinc(string link)
    {
        var request = UnityWebRequest.Get(link);
        await request.SendWebRequest();

        if (request.isNetworkError)
        {
            request.Dispose();
            Debug.Log($"Failed to load data by link: {link}");
            return default;
        }

        var personData = JsonUtility.FromJson<T>(request.downloadHandler.text);
        request.Dispose();
        return personData;
    }

}