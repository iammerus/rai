namespace Rai.TTS
{
    public interface ITtsEngine
    {
        string Title { get; }

        void Speak(string text);

        void SpeakAsync(string text);

        void SpeakAsyncCancelAll();
    }
}