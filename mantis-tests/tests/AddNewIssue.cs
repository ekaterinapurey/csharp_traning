using System;
namespace mantis_tests
{
	[TestFixture]
	public class AddNewIssueTests: TestBase
	{
		[Test]
        public void CreateNewIssue()
		{
			AccountData account = new AccountData()
			{
				Name = "administrator",
				Password = "root"
			};
			ProjectData project = new ProjectData()
			{
				Id = "1",
			};
            IssueData issue = new IssueData()
			{
				Summary = "some short",
				Description = "some long",
				Category = "General",
			};
			app.API.CreateNewIssue(account, project, issue);
		}
	}
}

