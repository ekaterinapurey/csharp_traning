using System.Collections.Generic;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Create(ProjectData project)
        {
            InitProjectCreation();
            driver.FindElement(By.XPath("//input[@id='project-name']")).SendKeys(project.Name);
            SubmitProjectCreation();

        }

        public ProjectHelper InitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='создать новый проект']")).Click();
            return this;
        }
        public ProjectHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            return this;
        }
        public List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();
            manager.Navigator.GoToControlPanel();
            manager.Navigator.GoToProjectControlPanel();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tbody//tr//a"));
            foreach (IWebElement element in elements)
            {
                projects.Add(new ProjectData(element.Text));
            }

            return projects;

        }

        public void Remove()
        {
            GoToProject();
            InitRemoveProject();
            SubmitRemoveProject();

        }

        public void GoToProject()
        {
            driver.FindElement(By.XPath("(//tbody//tr//td//a)[1]")).Click();
        }
        public void InitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value = 'Удалить проект']")).Click();
        }
        public void SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value = 'Удалить проект']")).Click();
        }
    }
}