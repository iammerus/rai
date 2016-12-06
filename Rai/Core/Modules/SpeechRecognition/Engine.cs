namespace Rai.Core.Modules.SpeechRecognition
{
    internal class Engine : System.Speech.Recognition.SpeechRecognitionEngine, IRecognitionEngine
    {
        /// <summary>
        /// Identifier for the speech recognition engine
        /// </summary>
        public string Title { get; } = "Microsoft Speech Recognition Engine - Online";

        /// <summary>
        /// GC
        /// </summary>
        public void _Dispose()
        {
            Dispose();
        }
    }
}
