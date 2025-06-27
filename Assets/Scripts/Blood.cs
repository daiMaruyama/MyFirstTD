using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] private LineRenderer[] bloodVesselPaths;

    // ���ǃ��[�g�������_���ɕԂ�
    public LineRenderer GetRandomPath()
    {
        if (bloodVesselPaths == null || bloodVesselPaths.Length == 0)
        {
            Debug.LogError("BloodVesselManager: ���[�g���ݒ肳��Ă��܂���");
            return null;
        }
        int index = Random.Range(0, bloodVesselPaths.Length);
        return bloodVesselPaths[index];
    }
}
