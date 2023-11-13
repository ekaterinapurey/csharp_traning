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
            List<ProjectData> projects = new List<ProjectData>();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            Mantis.ProjectData[] projectsMantis = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData item in projectsMantis)
            {
                projects.Add(new ProjectData(item.name)
                {
                    Id = item.id,
                    Description = item.description
                });
            }
            return projects;
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectCreation = new Mantis.ProjectData();
            projectCreation.name = project.Name;
           
            client.mc_project_addAsync(account.Name, account.Password, projectCreation);
        }
    }
}

