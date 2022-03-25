using System;
using System.Collections.Generic;

namespace TEams.Classes
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Project
	{
		public Project(string name,string description, string startDate, string dueDate)
		{
			this.Name = name;
			this.Description = description;
			this.StartDate = startDate;
			this.DueDate = dueDate;

		}

		public string Name { get; set; }
		public string Description { get; set; }
		public string StartDate { get; set; }
		public string DueDate { get; set; }

		//List<Employee> TeamMembers = new List<Employee>();
		public List<Employee> TeamMembers { get; set; }
	}
}