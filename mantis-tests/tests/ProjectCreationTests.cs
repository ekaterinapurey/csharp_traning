using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            List<ProjectData> projects = app.API.GetProjects(account);
            ProjectData project = new ProjectData("test" + TestBase.GenerateRandomString(5));
            app.Navigator.GoToControlPanel();
            app.Navigator.GoToProjectControlPanel();
            app.Project.Create(project);
            List<ProjectData> newProjects = app.API.GetProjects(account);
            projects.Add(project);
            projects.Sort();
            newProjects.Sort();
            Assert.AreEqual(projects, newProjects);
        }
    }
}