using Rai.Modules.Language;

namespace Rai.Modules
{
    /// <summary>
    /// Base interface for Rai module
    /// </summary>
    public interface IModule : IModuleBase
    {
        /// <summary>
        /// Get the name of the module
        /// </summary>
        /// <returns>string</returns>
        string GetName();

        /// <summary>
        /// Get the description of the module
        /// </summary>
        /// <returns></returns>
        string GetDescription();

        /// <summary>
        /// Get the information for the module query text
        /// </summary>
        /// <returns></returns>
        MatchInfo GetRunInformation();

        /// <summary>
        /// Runs the action of the module
        /// </summary>
        void Run();
    }
}
