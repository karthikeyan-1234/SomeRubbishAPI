namespace SomeRubbishAPI.Models
{
    /*Model for SELECT TOP (1000) [first_Name]
      ,[last_Name]
      ,[ID]
  FROM [TestDB].[dbo].[tblemployee]*/

    using System;

    public class Employee
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }


}
