using System.ComponentModel;

namespace Backend.Infrastructure.enums;

public enum IfDdeEnum
{
    [Description("MILD")]
    Mild,
    [Description("MODERATE")]
    Moderate,
    [Description("SEVERE")]
    Severe,
    [Description("DRUG ABUSE AND DEPENDENCE")]
    DrugAbuseAndDependence,
    [Description("NONE")]
    None
}