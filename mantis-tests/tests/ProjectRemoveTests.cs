﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemoveTests : TestBase
    {
        [Test]
        public void ProjectRemovingTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            List<ProjectData> projects = app.API.GetProjects(account);
            if (projects.Count == 0)
            {
                ProjectData newProject = new ProjectData("test" + TestBase.GenerateRandomString(5));
                app.Navigator.GoToControlPanel();
                app.Navigator.GoToProjectControlPanel();
                app.Project.Create(newProject);
                projects = app.Project.GetProjects();
            }
            app.Navigator.GoToControlPanel();
            app.Navigator.GoToProjectControlPanel();
            app.Project.Remove();
            List<ProjectData> newProjects = app.Project.GetProjects();
            Assert.AreEqual(projects.Count() - 1, newProjects.Count());
        }
    }
}