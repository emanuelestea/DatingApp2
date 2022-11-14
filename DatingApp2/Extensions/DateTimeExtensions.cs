using System;

public static class DateTimeExtensions
{
	public static int CalculateAge(this DateTime dob)
	{
		var Today = DateTime.Today;
		var Age = Today.Year - dob.Year;
		if (dob.Date > Today.AddYears(-Age)) --Age;
		return Age;
	}
}
