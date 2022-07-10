using _3.BonusChallenge.Interfaces;
using _3.BonusChallenge.Services;
using AnagramsShared.Interfaces;
using AnagramsShared.Services;
using System;

using Unity;

namespace _3.BonusChallenge
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var unityContainer = new UnityContainer();
              RegisterTypes(unityContainer);
              return unityContainer;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterSingleton<IAnagramsChecker, AnagramsChecker>();
            container.RegisterSingleton<IConfigHandler, ConfigHandler>();
        }
    }
}