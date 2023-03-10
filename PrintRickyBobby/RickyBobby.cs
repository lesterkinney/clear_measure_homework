using PrintRickyBobby.Interfaces;
using PrintRickyBobby.Models;

namespace PrintRickyBobby
{
    /// <summary>
    /// Class to print name paired with a value that is divisible by a number evenly
    /// For example: if the name is 'Name1' and value is 5, then the name will print 
    /// when the counter is divisible evenly by that number.
    /// There are 2 and only 2 name/value pairs allowed.
    /// Exceptions are thrown when:
    /// 1) The UpperBound is GT than the MaximumUpperBoundAllowed value in RickyBobbyArgument
    /// 2) The UpperBound is GT the Page * PageCount value
    /// 3) Any of the integer values in RickyBobbyArgument are < 0
    /// 4) The count of ModNamePairs != 2
    /// The default MaximumUpperBoundAllowed value is 250,000
    /// </summary>
    public class RickyBobby : IRickyBobby
    {
        /// <summary>
        /// Processes the printing of a number, 'name1', 'name2' or 'name1 name2'
        /// </summary>
        /// <param name="args">An instantiation of the RickyBobbyArgument class with values for processing.</param>
        /// <returns>A list type=string of the results.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public List<string> PrintRickyBobby(RickyBobbyArgument args)
        {
            if (args.UpperBound < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(args.UpperBound),
                    "The UpperBound cannot be less than 0.");
            }

            if(args.Page < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(args.Page),
                    "The Page cannot be less than 0.");
            }

            if (args.PageCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(args.PageCount),
                    "The PageCount cannot be less than 0.");
            }

            if (args.PageCount * args.Page > args.UpperBound)
            {
                throw new ArgumentOutOfRangeException(nameof(args),
                    $"The {nameof(args.UpperBound)} argument must be greater than the {nameof(args.Page)} * {nameof(args.PageCount)} value.");
            }

            if(args.ModNamePairs.Count != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(args.ModNamePairs), 
                    "Number of arguments must be 2.");
            }

            if(args.UpperBound > args.MaximumUpperBoundAllowed)
            {
                throw new ArgumentOutOfRangeException(nameof(args.UpperBound), 
                    $"The UpperBound cannot be greater than {args.MaximumUpperBoundAllowed}.");
            }

            var firstKey = args.ModNamePairs.Values.First();
            var secondKey = args.ModNamePairs.Values.Last();
            var firstName = args.ModNamePairs.Keys.First();
            var secondName = args.ModNamePairs.Keys.Last();
            var concatName = firstName + " " + secondName;
            int indexStart;
            int indexStop;
            if(args.Page == 0 && args.PageCount == 0)
            {
                indexStart = 1;
                indexStop = args.UpperBound;
            }
            else
            {
                indexStart = ((args.Page - 1) * args.PageCount) + 1;
                indexStop = indexStart + args.PageCount - 1;
            }


            var printList = new List<string>(indexStop - indexStart);
            
            for (int i = indexStart; i <= indexStop; i++)
            {
                if (!(i % firstKey == 0 || i % secondKey == 0))
                {
                    printList.Add(i.ToString());
                }
                else
                {
                    if (i % firstKey == 0 && i % secondKey == 0)
                    {
                        printList.Add(concatName);
                    }
                    else
                    {
                        if (i % firstKey == 0)
                        {
                            printList.Add(firstName);
                        }
                        if (i % secondKey == 0)
                        {
                            printList.Add(secondName);
                        }
                    }

                }

            }

            return printList;
        }

    }
}