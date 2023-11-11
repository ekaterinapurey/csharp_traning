﻿using System;
namespace mantis_tests
{
	public class APIHelper : HelperBase
	{
		public APIHelper(ApplicationManager manager): base(manager)
		{
		}

        public void CreateNewIssue(AccountData account, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            client.mc_issue_add(account.Name, account.Password, issue);
        }
    }
}
