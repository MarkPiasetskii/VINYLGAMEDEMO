using UnityEngine;
using FMODUnity;

public class Soundtest : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string audioEvent;

    private FMOD.Studio.EventInstance audioInstance;

    void Start()
    {
        // Инициализация FMOD
        audioInstance = RuntimeManager.CreateInstance(audioEvent);
        audioInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
    }

    void Update()
    {
        // Проверка нажатия клавиши пробел
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Вызов функции для проигрывания звука
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        // Воспроизведение звука
        audioInstance.start();
    }

    void OnDestroy()
    {
        // Освобождение ресурсов FMOD при уничтожении объекта
        audioInstance.release();
    }
}