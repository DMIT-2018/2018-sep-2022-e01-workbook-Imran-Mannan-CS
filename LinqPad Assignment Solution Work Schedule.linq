<Query Kind="Statements" />

//Assignment 1 WorkSchedule
// Question1
var q1 = Skills
         .Where(s => s.EmployeeSkills.Count() == 0)
		 .Select(x => x.Description);
q1.Dump();

//Q2
var q2 = Skills
		 .Where(s => s.RequiresTicket)
		 .Select(s => new
		 		 {
				 	Description = s.Description,
					Employees = s.EmployeeSkills
								.OrderByDescending(x => YearsOfExprience)
					            .Select(x => new 
								{
									Name = x.Employee.FirstName + " " + x.Employee.LastName,
									Level= x.Level == 1 ? "Novice":
										   x.Level == 2 ? "Proficient" : "Expert",
									YearsOfExprience=x.YearsOfExperience
								
								})
				 
				 });
		q2.Dump();
		
		
//Q3
var q3 = Employees
		 .Where(e => e.EmployeeSkills.Count() > 1)
		 .Select(e => new
		 {
		 	Name = e.FirstName + " " + e.LastName,
			Skills = e.EmployeeSkills
						.Select(es = new 
						{
							Description = es.Skill.Description,
									Level= es.Level == 1 ? "Novice":
										   es.Level == 2 ? "Proficient" : "Expert",
									YearsOfExprience=es.YearsOfExperience
						
						})
		 
		 });
		 


q3.Dump();




//Q4
var q4 = Shifts
		 .Where(s => s.PlacementContract.Location.Name.Contains("Nait"))
		 .GroupBy(s => s.DayOfWeek)
		 .Select(gsd => new
		 {
		 	DayofWeek = gsd.Key == 0 ? "Sun" :
						gsd.Key == 1 ? "Mon" :
						gsd.Key == 2 ? "Tue" :
						gsd.Key == 3 ? "Wed" :
						gsd.Key == 4 ? "Thu" :
						gsd.Key == 5 ? "Fri" : "Sat"
						 
			NumberOfEmployees = gsd.Sum(x => x.NumberOfEmployees),
			shifts = gsd
					.Select(y => new
					{
						id = y.ShiftID,
						Start = y.StartTime,
						End = y.EndTime,
						NoE = y.NumberOfEmployees
					})
		 
		 
		 });




q4.Dump();


//Q5
var parta = Employees
			.Select( x => new
			{
				Name = x.FirstName + " " + x.LastName,
				YOE = x.EmployeeSkills.Sum(es => es.YearsOfExperience)
			});
			.OrderByDescending(x => x.YOE);
			
var maxYears = parta
				.Max(p => p.YOE);
			
var q5 = parta
		.Where(x => x.YOE == maxYears);


q5.Dump();

//Q5 one query
var q5onequery = Employees
				.Select( x => new
			{
				Name = x.FirstName + " " + x.LastName,
				YOE = x.EmployeeSkills.Sum(es => es.YearsOfExperience)
			})
			.GroupBy(x => x.YOE)
			.OrderByDescending(x => x.Key)
			.First()
			.Dump();
			
			
//Q6

var q6 = Schedules
         .Where(x => x.Day.Month == 3)
		 .ToList()
		 .GroupBy(x => x.Employee) 
		 .Select(x => new
		 {
		 	Name = x.Key.FirstName + " " + x.Key.LastName,
			RegularEarnings = x.Where(y => !y.OverTime).Sum(y => y.HourlyWage *
				(y.Shift.EndTime - y.Shift.StartTime).Hours).ToString("0.00"),
			OvertimeEarnings = x.Where(y => !y.OverTime).Sum(y => y.HourlyWage *
				(y.Shift.EndTime - y.Shift.StartTime).Hours * 1.5m).ToString("0.00"),
			NumberOfShifts = x.Count()
		 });
q6.Dump();





