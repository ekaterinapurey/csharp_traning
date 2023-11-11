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
            List<ProjectData> projects = new List<ProjectData>();
            projects = app.Project.GetProjects();
            ProjectData project = new ProjectData("test" + TestBase.GenerateRandomString(5));
            app.Navigator.GoToControlPanel();
            app.Navigator.GoToProjectControlPanel();
            app.Project.Create(project);
            List<ProjectData> newProjects = app.Project.GetProjects();
            projects.Add(project);
            projects.Sort();
            newProjects.Sort();
            Assert.AreEqual(projects, newProjects);
        }
    }
}