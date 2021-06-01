using System;
using UnityEngine;

namespace Andtech.Ego
{

    public interface IProjectileTask
    {
        Vector3 CurrentPosition { get; }

        void Run();

        #region EVENT
        event EventHandler<ImpactEventArgs> Impacted;
        #endregion
    }

    public interface IProjectileTaskLifetime
    {

        #region PIPELINE
        event EventHandler Launched;
        event EventHandler Destroyed;
        #endregion
    }
}
