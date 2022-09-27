using AutoFixture;
using HospitalManagementSystem.Controllers;
using HospitalManagementSystem.Core.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsUnitTest
{
    [TestClass]
    public class HospitalControllerTest
    {
        private Mock<IHospital> _RepoMock;
        private Fixture _fixture;

        private HospitalController _controller;
        public HospitalControllerTest()
        {
            _fixture = new Fixture();
            _RepoMock = new Mock<IHospital>();
        }
        [TestMethod]
        public async Task GetDisplayAllHospitalsReturnOk()
        {
            var hospitalList = _fixture.CreateMany<HospitalModel>(3).ToList();
            _RepoMock.Setup(repo => repo.DisplayAllHospitals()).Returns(hospitalList);
            _controller = new HospitalController(_RepoMock.Object);
            var result = await _controller.DisplayAllHospitals();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetDisplayAllHospitalsThrowException()
        {
            _RepoMock.Setup(repo => repo.DisplayAllHospitals()).Throws(new Exception());
            _controller = new HospitalController(_RepoMock.Object);
            var result = await _controller.DisplayAllHospitals();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddHospitalReturnOk()
        {
            var hospital = _fixture.Create<HospitalModel>();
            _RepoMock.Setup(repo => repo.AddHospital(It.IsAny<HospitalModel>())).Returns(hospital);
            _controller = new HospitalController(_RepoMock.Object);
            var result = await _controller.AddHospital(hospital);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddHospitalThrowException()
        {
            _RepoMock.Setup(repo => repo.DisplayAllHospitals()).Throws(new Exception());
            _controller = new HospitalController(_RepoMock.Object);
            var result = await _controller.DisplayAllHospitals();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
    }
}
