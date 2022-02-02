using System.Globalization;

DateTime todayLocal = DateTime.Now; // local time
DateTime todayGlobal = DateTime.UtcNow; // global time

DateTime birthdayJoe = DateTime.Parse("21-01-1960");
DateTime birthdayDave = DateTime.ParseExact("08/02/1951", "dd/MM/yyyy", CultureInfo.InvariantCulture);

Console.WriteLine(todayLocal);
Console.WriteLine(todayLocal.ToString("d"));
Console.WriteLine(todayLocal.ToShortTimeString());

Console.WriteLine(birthdayJoe.ToShortDateString());

// DateOnly
DateOnly birthdayCarry = DateOnly.Parse(DateTime.Now.AddYears(-30).ToShortDateString());
Console.WriteLine(birthdayCarry);

// TimeOnly
TimeOnly timeHappened = TimeOnly.FromDateTime(DateTime.Now);
Console.WriteLine(timeHappened);
