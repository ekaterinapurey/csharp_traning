using System;
namespace mantis_tests
{
	public class APIHelper : HelperBase
	{
		public APIHelper(ApplicationManager manager): base(manager)
		{
		}

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.Id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            return client.mc_projects_get_user_accessible(account.Name, account.Password);
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectCreation = new Mantis.ProjectData();
            projectCreation.name = project.Name;
           
            client.mc_project_add(account.Name, account.Password, projectCreation);
        }
    }
}

