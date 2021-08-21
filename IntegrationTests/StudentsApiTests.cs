﻿using ClassroomApi.DTOs;
using ClassroomApi.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static IntegrationTests.Helper;

namespace IntegrationTests
{
    [TestClass]
    public class StudentsApiTests
    {

        public CustomWebApplicationFactory _factory = new CustomWebApplicationFactory();

        [TestMethod]
        public async Task GetRequestOfStudentsEndpoint_ShouldReturnOkStatusCode()
        {
            // Arrange
            string url = "/api/students/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetRequestOfStudentsEndpoint_ShouldReturnExpectedStudentsData()
        {
            // Arrange
            string url = "/api/students/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            StudentDto[] students = await DeserializeResponse<StudentDto[]>(response);
            Assert.AreEqual(3, students.Length);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetRequestOfStudentsEndpointWithId_ShouldReturnExpectedStudentData()
        {
            // Arrange
            int id = 1;
            string url = "/api/students/" + id;
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            StudentDto student = await DeserializeResponse<StudentDto>(response);
            Assert.AreEqual("Harry", student.FirstName);
            Assert.AreEqual("Davidson", student.LastName);
            Assert.AreEqual(14, student.Age);
            Assert.AreEqual(1, student.ClassId);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PostRequestOfStudentsToStudentsEndpoint_ShouldAddTheStudent()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            var studentToPost = new StudentDto()
            {
                FirstName = "Peter",
                ClassId = 1
            };
            string url = "/api/students/";
            StringContent serializedStudent = SerializeObject(studentToPost);

            // Act
            HttpResponseMessage response = await client.PostAsync(url, serializedStudent);

            // Assert
            StudentDto studentResponse = await DeserializeResponse<StudentDto>(response);
            Assert.AreEqual(studentToPost.FirstName, studentResponse.FirstName);
            int expectedIdOfNewStudent = 4;
            Assert.AreEqual(expectedIdOfNewStudent, studentResponse.StudentId);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PostRequestOfStudentsToStudentsEndpoint_WithNonExistentClass_ShouldReturnNoContentStatusCode()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            var studentToPost = new StudentDto()
            {
                FirstName = "Peter",
                ClassId = 123
            };
            string url = "/api/students/";
            StringContent serializedStudent = SerializeObject(studentToPost);

            // Act
            HttpResponseMessage response = await client.PostAsync(url, serializedStudent);

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
