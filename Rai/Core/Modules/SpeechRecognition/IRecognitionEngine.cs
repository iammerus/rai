namespace Rai.Core.Modules.SpeechRecognition
{
    public interface IRecognitionEngine
    {
        string Title { get; }

        void _Dispose();
    }
}