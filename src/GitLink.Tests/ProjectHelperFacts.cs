﻿using System.Linq;
using NUnit.Framework;

namespace GitLink.Tests {
    [TestFixture]
    public class ProjectHelperFacts {
        private const string SolutionFile = @"TestSolution\TestSolution.sln";

        [Test]
        public void GettingProjectsFromSolution() {
            Assert.AreEqual(3, ProjectHelper.GetProjects(SolutionFile, Configuration.Debug, Platform.AnyCpu).Count());
        }

        [Test]
        public void GettingProjectsFromSolution_SkipsProjectNotSelectedForPlatform() {
            var projects = ProjectHelper.GetProjects(SolutionFile, Configuration.Debug, Platform.x64).ToList();

            Assert.AreEqual(2, projects.Count);
            Assert.False(projects.Any(c => c.GetProjectName() == "BuiltInAnyCpuOnly"));
        }

        [Test]
        public void GettingProjectsFromSolution_SkipsProjectNotSelectedForConfiguration() {
            var projects = ProjectHelper.GetProjects(SolutionFile, Configuration.Release, Platform.AnyCpu).ToList();

            Assert.AreEqual(2, projects.Count);
            Assert.False(projects.Any(c => c.GetProjectName() == "BuiltInDebugOnly"));
        }

        [Test]
        public void GettingProjectsFromSolution_SkipsProjectNotSelectedForEitherConfigurationOrPlatform() {
            var project = ProjectHelper.GetProjects(SolutionFile, Configuration.Release, Platform.x64).Single();

            Assert.AreEqual("BuiltAlways", project.GetProjectName());
        }

        private static class Configuration {
            public const string Debug = "Debug";
            public const string Release = "Release";
        }

        private static class Platform {
            public const string AnyCpu = "Any CPU";
            public const string x64 = "x64";
        }
    }
}