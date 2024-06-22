using System;
using System.ComponentModel.DataAnnotations;

public class DynamicRangeAttribute : RangeAttribute
{
    public DynamicRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
    {
        ErrorMessage = $"Must be in range: {minimum} - {DateTime.Now.Year}.";
    }
}
