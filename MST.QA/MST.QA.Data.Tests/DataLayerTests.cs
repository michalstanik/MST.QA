﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MST.QA.Core.Data;
using MST.QA.Core.DataInterfaces;
using MST.QA.Data.Contracts.RepositoryInterfaces;
using MST.QA.DataModel.Projects;
using MST.QA.Server.Bootstrapper;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MST.QA.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<Project> projects = repositoryTest.GetProjects();

            Assert.IsTrue(projects != null);
        }

        [TestMethod]
        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<Project> projects = factoryTest.GetProjects();

            Assert.IsTrue(projects != null);
        }

    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryTestClass(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [Import]
        IProjectRepository _projectRepository;

        public IEnumerable<Project> GetProjects()
        {
            IEnumerable<Project> projects = _projectRepository.Get();

            return projects;
        }

    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _dataRepositoryFactory;

        public IEnumerable<Project> GetProjects()
        {
            IProjectRepository projectRepository = _dataRepositoryFactory.GetDataRepository<IProjectRepository>();

            IEnumerable<Project> projects = projectRepository.Get();

            return projects;
        }
    }
}