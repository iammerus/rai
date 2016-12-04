using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rai.Modules.Language
{
    public class MatchInfo
    {
        /// <summary>
        /// Get the keywords for the statement
        /// </summary>
        public string[] Keywords { get; private set; }

        public StatementType Type { get; private set; }

        public MatchInfo(string[] keywords, StatementType type)
        {
            this.Keywords = keywords;
            this.Type = type;
        }
    }
}
