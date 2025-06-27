using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] private LineRenderer[] bloodVesselPaths;

    // 血管ルートをランダムに返す
    public LineRenderer GetRandomPath()
    {
        if (bloodVesselPaths == null || bloodVesselPaths.Length == 0)
        {
            Debug.LogError("BloodVesselManager: ルートが設定されていません");
            return null;
        }
        int index = Random.Range(0, bloodVesselPaths.Length);
        return bloodVesselPaths[index];
    }
}
