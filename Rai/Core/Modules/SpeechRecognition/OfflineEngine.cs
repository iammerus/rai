namespace Rai.Core.Modules.SpeechRecognition
{
    internal class OfflineEngine : System.Speech.Recognition.SpeechRecognitionEngine, IRecognitionEngine
    {
        /// <summary>
        /// Identifier for the speech recognition engine
        /// </summary>
        public string Title { get; } = "Microsoft Speech Recognition Engine - Offline";

        /// <summary>
        /// GC
        /// </summary>
        public void _Dispose()
        {
            Dispose();
        }
    }
}
