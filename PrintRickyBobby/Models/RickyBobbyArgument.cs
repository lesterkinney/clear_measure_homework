using PrintRickyBobby.Interfaces;

namespace PrintRickyBobby.Models
{
    public  class RickyBobbyArgument : IRickyBobbyArguments
    {
        public int MaximumUpperBoundAllowed { get; set; } = 250000;
        public int UpperBound { get; set; }

        public Dictionary<string, int> ModNamePairs { get; set; } = new Dictionary<string, int>();
        public int Page { get; set; }
        public int PageCount { get; set; }

    }
}
