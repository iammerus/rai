using Rai.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rai
{
    public class Application 
    {
        /// <summary>
        /// IoC container for the application
        /// </summary>
        public Container Container { get; private set; }

        /// <summary>
        /// Indicates whether application core modules have finished initializing
        /// </summary>
        protected bool BootComplete = false;

        /// <summary>
        /// Indicates whether application modules have been bootstrapped and initialized
        /// </summary>
        protected bool BootstrapComplete = false;

       /// <summary>
       /// Application version
       /// </summary>
        protected const string RaiVersion = "1.0.0";


        /// <summary>
        /// Store the current state of the application
        /// </summary>
        protected static State State = State.Offline;

        /// <summary>
        /// App constructor
        /// </summary>
        /// <param name="container">Container instance</param>
        public Application(Container container)
        {
            this.Container = container;
        }


        /// <summary>
        /// Boots the application and gets it ready to respond to a user's 
        /// </summary>
        public void Boot()
        {
            this.RegisterCoreModules();

            this.RegisterExternalModules();
        }

        /// <summary>
        /// This creates and initializes the core modules of the application
        /// </summary>
        protected void RegisterCoreModules()
        {
            this.InitializeTTS();
        }

        private void InitializeTTS()
        {
            throw new NotImplementedException();
        }

        protected void InitializeRecognitionEngine()
        {
            
        }

        /// <summary>
        /// Registers module classes and activation sequences for later use in the application
        /// </summary>
        protected void RegisterExternalModules()
        {

        }

        /// <summary>
        /// Get the current version of the application
        /// </summary>
        /// <returns>Current version</returns>
        public Version Version()
        {
            return new Version(Application.RaiVersion);
        }


        /// <summary>
        /// Get the current state of the application
        /// </summary>
        /// <returns></returns>
        public static State GetApplicationState()
        {
            return State;
        }

        /// <summary>
        /// Set the current state of the application
        /// </summary>
        /// <param name="state">The new state of the application</param>
        public static void SetState(State state)
        {
            State = state;
        }
    }
}
