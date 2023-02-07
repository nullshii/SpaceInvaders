using UnityEngine;
using Zenject;

namespace Code.Scripts.Installers
{
    public class InvaderManagerInstaller : MonoInstaller
    {
        [SerializeField] private InvaderManager _invaderManager;

        public override void InstallBindings()
        {
            Container.Bind<InvaderManager>()
                .FromInstance(_invaderManager)
                .AsSingle();
        }
    }
}