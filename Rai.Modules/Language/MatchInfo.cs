namespace Rai.Modules.Language
{
    public class MatchInfo
    {
        public MatchInfo(string[] keywords, StatementType type)
        {
            Keywords = keywords;
            Type = type;
        }

        /// <summary>
        ///     Get the keywords for the statement
        /// </summary>
        public string[] Keywords { get; private set; }

        public StatementType Type { get; private set; }
    }
}