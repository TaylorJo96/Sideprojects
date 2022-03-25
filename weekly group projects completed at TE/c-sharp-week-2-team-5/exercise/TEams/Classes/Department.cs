using System;
using System.Collections.Generic;

namespace TEams.Classes
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Department
	{
		public Department(int departmentId, string name)
		{
			this.DepartmentId = departmentId;
			this.Name = name;

		}

		public int DepartmentId { get; set; }
		public string Name { get; set; }
		
	}
}