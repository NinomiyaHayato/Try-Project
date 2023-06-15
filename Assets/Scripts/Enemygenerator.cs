using System.Collections;
using UnityEngine;

public class Enemygenerator : MonoBehaviour
{
    [SerializeField, Header("���X�|�[��������ꏊ")] GameObject[] _respawn;
    [SerializeField, Header("���X�|�[���܂ł̃��~�b�g")] float _limitTime;
    [SerializeField, Header("�G�̃I�u�W�F�N�g")] GameObject _enemy;
    [SerializeField] float _time;//���Z���錳�̎���

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int index = Random.Range(0, _respawn.Length - 1);
            Vector3 respawn = _respawn[index].transform.position;
            Instantiate(_enemy, respawn,new Quaternion(0f,0f,0f,0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }
    public void Respawn()
    {
        _time += Time.deltaTime;
        if (_time > _limitTime && FindObjectsOfType<EnemyMove>().Length < 30)
        {
            for (int i = FindObjectsOfType<EnemyMove>().Length; i < 20; i++)
            {
                int index = Random.Range(0, _respawn.Length);
                Instantiate(_enemy, _respawn[index].transform.position,new Quaternion(0f,0f,0f,0f));
            }
            _time = 0;
        }
    }
}
