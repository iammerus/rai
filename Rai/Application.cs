using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using Rai.Core.IoC;
using Rai.Core.Modules.SpeechRecognition;
using Rai.TTS;

namespace Rai
{
    public class Application : IDisposable
    {
        /// <summary>
        ///     IoC container for the application
        /// </summary>
        public Container Container { get; private set; }

        /// <summary>
        ///     Indicates whether application core modules have finished initializing
        /// </summary>
        protected static bool BootComplete;

        /// <summary>
        ///     Indicates whether application modules have been bootstrapped and initialized
        /// </summary>
        protected static bool BootstrapComplete = false;

        /// <summary>
        ///     Application version
        /// </summary>
        protected const string RaiVersion = "1.0.0";


        /// <summary>
        ///     Store the current state of the application
        /// </summary>
        protected static State State = State.Offline;

        /// <summary>
        ///     Application speech synthesis engine
        /// </summary>
        protected ITtsEngine Synthesizer;

        /// <summary>
        ///     Application speech recognition engine
        /// </summary>
        protected IRecognitionEngine RecognitionEngine;

        protected IRecognitionEngine OfflineRecognitionEngine;

        /// <summary>
        ///     Application constructor
        /// </summary>
        /// <param name="container">Container instance</param>
        public Application(Container container)
        {
            Container = container;
        }


        /// <summary>
        ///     Boots the application and gets it ready to respond to a user's
        /// </summary>
        public void Boot()
        {
            RegisterCoreModules();

            RegisterExternalModules();

            SetBootComplete();
        }

        /// <summary>
        ///     Updates the 'boot' state of the application to complete
        /// </summary>
        private void SetBootComplete()
        {
            BootComplete = true;
        }

        /// <summary>
        ///     This creates and initializes the core modules of the application
        /// </summary>
        protected void RegisterCoreModules()
        {
            InitializeTts();

            InitializeRecognitionEngine();
        }

        /// <summary>
        /// </summary>
        private void InitializeTts()
        {
            // Remember to update method to use user's default selected speech synthesizer
            Synthesizer = new MicrosftTts(new SpeechSynthesizer());
            // Use unity to resolve dependencies and inject them;
        }

        protected void InitializeRecognitionEngine()
        {
            RecognitionEngine = new Engine();
            OfflineRecognitionEngine = new OfflineEngine();
        }

        /// <summary>
        ///     Registers module classes and activation sequences for later use in the application
        /// </summary>
        protected void RegisterExternalModules()
        {
        }

        /// <summary>
        ///     Get the current version of the application
        /// </summary>
        /// <returns>Current version</returns>
        public Version Version()
        {
            return new Version(RaiVersion);
        }

        /// <summary>
        ///     Get the title (name) of application's speech recognition engine
        /// </summary>
        /// <returns>Speech recognition engine's title</returns>
        public string GetSpeechRecognitionEngineTitle()
        {
            return RecognitionEngine.Title;
        }

        /// <summary>
        ///     Get the title (name) of the application's speech synthesizer
        /// </summary>
        /// <returns></returns>
        public string GetSpeechTtsEngineTitle()
        {
            return Synthesizer.Title;
        }

        /// <summary>
        /// Passes a command for the application's speech synthesizer
        /// </summary>
        /// <param name="text"></param>
        public void Speak(string text)
        {
            this.Synthesizer.Speak(text);
        }

        /// <summary>
        /// Asynchronously passes a command for the application's speech synthesizer
        /// </summary>
        /// <param name="text"></param>
        public void SpeakAsync(string text)
        {
            this.Synthesizer.SpeakAsync(text);
        }

        /// <summary>
        /// Cancels all queued asynchronous speech synthesis jobs
        /// </summary>
        public void SpeakAsyncCancelAll()
        {
            this.Synthesizer.SpeakAsyncCancelAll();
        }

        /// <summary>
        ///     Get the current state of the application
        /// </summary>
        /// <returns></returns>
        public static State GetApplicationState()
        {
            return State;
        }

        /// <summary>
        ///     Checks if the application has finished 'booting'
        /// </summary>
        /// <returns></returns>
        public static bool IsBootComplete()
        {
            return BootComplete;
        }

        /// <summary>
        ///     Set the current state of the application
        /// </summary>
        /// <param name="state">The new state of the application</param>
        public static void SetState(State state)
        {
            State = state;
        }

        #region IDisposable Support

        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    OfflineRecognitionEngine._Dispose();
                    RecognitionEngine._Dispose();
                }

                OfflineRecognitionEngine = null;
                RecognitionEngine = null;

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Application() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
