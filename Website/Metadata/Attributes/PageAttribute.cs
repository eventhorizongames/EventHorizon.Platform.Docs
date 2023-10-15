namespace Website.Metadata.Attributes;

using System;

[AttributeUsage(AttributeTargets.Class)]
public class PageAttribute : Attribute
{
    public float Order { get; set; }
    public string Title { get; set; } = string.Empty;
}
