using UnityEngine;
using FMODUnity;

/*public class FootstepSoundManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string sprintsoundEventPath = "event:/steps/sprintsound";
    [FMODUnity.EventRef]
    public string crouchsoundEventPath = "event:/steps/crouchsound";
    [FMODUnity.EventRef]
    public string stepregularEventPath = "event:/steps/stepregular";
    [FMODUnity.EventRef]
    public string jumpsound;
    [FMODUnity.EventRef]
    public string landingsoundEventPath = "event:/steps/landingsound";

    private FMOD.Studio.EventInstance sprintsoundEvent;
    private FMOD.Studio.EventInstance crouchsoundEvent;
    private FMOD.Studio.EventInstance stepregularEvent;
    private FMOD.Studio.EventInstance jumpsoundInstance;
    private FMOD.Studio.EventInstance landingsoundEvent;

     void Start()
    {
        jumpsoundInstance = RuntimeManager.CreateInstance(jumpsound);
        jumpsoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));

    }

    private void Awake()
    {
        // Инициализация звуковых событий FMOD
        sprintsoundEvent = FMODUnity.RuntimeManager.CreateInstance(sprintsoundEventPath);
        crouchsoundEvent = FMODUnity.RuntimeManager.CreateInstance(crouchsoundEventPath);
        stepregularEvent = FMODUnity.RuntimeManager.CreateInstance(stepregularEventPath);
        jumpsoundEvent = FMODUnity.RuntimeManager.CreateInstance(jumpsoundEventPath);
        landingsoundEvent = FMODUnity.RuntimeManager.CreateInstance(landingsoundEventPath);
    }

    public void Playsprintsound()
    {       
        sprintsoundEvent.start();
    }

    public void Playcrouchsound()
    {       
        crouchsoundEvent.start();
    }

    public void Playstepregular()
    {       
        stepregularEvent.start();
    }

    public void Playjumpsound()
    {       
        jumpsound.start();
    }

    public void Playlandingsound()
    {       
        landingsoundEvent.start();
    }


    // Добавьте другие методы воспроизведения звуков при беге, Crouch, прыжке и приземлении, аналогично предыдущему ответу.
}
*/

