using System.Speech.Synthesis;

namespace Rai.TTS
{
    internal class MicrosftTts : ITtsEngine
    {
        /// <summary>
        ///     SpeechSynthesizer instance
        /// </summary>
        protected SpeechSynthesizer Synthesizer;

        /// <summary>
        ///     Identifier for the speech recognition engine
        /// </summary>
        public string Title { get; } = "Microsoft Speech Synthesizer";

        public MicrosftTts(SpeechSynthesizer synthesizer)
        {
            Synthesizer = synthesizer;

            Initialize();
        }

        /// <summary>
        ///     Setup some of the synthesizer's default settings
        /// </summary>
        private void Initialize()
        {
            Synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
            Synthesizer.Volume = 100;
        }

        /// <summary>
        ///     Speaks the provided text
        /// </summary>
        /// <param name="text">The text to speak</param>
        public void Speak(string text)
        {
            Synthesizer.Speak(text);
        }

        /// <summary>
        ///     Asynchronously speak the provided text
        /// </summary>
        /// <param name="text">The text to speak</param>
        public void SpeakAsync(string text)
        {
            Synthesizer.SpeakAsync(text);
        }

        /// <summary>
        ///     Cancels all queued speech synthesis operations
        /// </summary>
        public void SpeakAsyncCancelAll()
        {
            Synthesizer.SpeakAsyncCancelAll();
        }
    }
}
