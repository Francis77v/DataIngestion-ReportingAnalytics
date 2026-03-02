using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum IncomeBracketEnum
{
    [Description("BELOW 10,000")]
    Below10k,

    [Description("10,001 - 20,000")]
    Range10kTo20k,

    [Description("20,001 - 40,000")]
    Range20kTo40k,

    [Description("40,001 - 60,000")]
    Range40kTo60k,

    [Description("60,001 AND ABOVE")]
    Above60k
}