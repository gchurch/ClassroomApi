using ClassroomApi.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestClass]
    public class ApiTests
    {

        public CustomWebApplicationFactory _factory = new CustomWebApplicationFactory();

        public StringContent SerializeObject(object objectToSerialize)
        {
            string productString = JsonConvert.SerializeObject(objectToSerialize);
            StringContent stringContent = new StringContent(productString, Encoding.UTF8, "application/json");
            return stringContent;
        }

        public async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }

        [TestMethod]
        public async Task GetRequestOfTeachersEndpoint_ShouldReturnOkStatusCode()
        {
            // Arrange
            string url = "/api/teachers/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetRequestOfTeachersEndpoint_ShouldReturnExpectedTeachersData()
        {
            // Arrange
            string url = "/api/teachers/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Teacher[] teachers = await DeserializeResponse<Teacher[]>(response);
            Assert.AreEqual(3, teachers.Length);
            Assert.AreEqual("David", teachers[0].FirstName);
            Assert.AreEqual("Michelle", teachers[1].FirstName);
            Assert.AreEqual("John", teachers[2].FirstName);
        }

        [TestMethod]
        public async Task GetRequestOfTeachersEndpointWithId_ShouldReturnExpectedTeacherData()
        {
            // Arrange
            int id = 1;
            string url = "/api/teachers/" + id;
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Teacher teacher = await DeserializeResponse<Teacher>(response);
            Assert.AreEqual("David", teacher.FirstName);
            Assert.AreEqual("Allen", teacher.LastName);
            Assert.AreEqual(30, teacher.Age);
            Assert.AreEqual("Maths", teacher.Subject);
        }

        [TestMethod]
        public async Task PostRequestOfTeachersToTeachersEndpoint_ShouldAddTheTeacher()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            var teacherToPost = new Teacher()
            {
                FirstName = "Peter"
            };
            string url = "/api/teachers/";
            StringContent serializedTeacher = SerializeObject(teacherToPost);

            // Act
            HttpResponseMessage response = await client.PostAsync(url, serializedTeacher);

            // Assert
            Teacher teacherResponse = await DeserializeResponse<Teacher>(response);
            Assert.AreEqual(teacherToPost.FirstName, teacherResponse.FirstName);
            int expectedIdOfNewTeacher = 4;
            Assert.AreEqual(expectedIdOfNewTeacher, teacherResponse.TeacherId);
        }
    }
}
