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
    public class ClassesApiTests
    {

        public CustomWebApplicationFactory _factory = new CustomWebApplicationFactory();

        [TestMethod]
        public async Task GetRequestOfClassesEndpoint_ShouldReturnOkStatusCode()
        {
            // Arrange
            string url = "/api/classes/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetRequestOfClassesEndpoint_ShouldReturnExpectedClassesData()
        {
            // Arrange
            string url = "/api/classes/";
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Class[] classes = await DeserializeResponse<Class[]>(response);
            Assert.AreEqual(1, classes.Length);
            Assert.AreEqual("Maths", classes[0].ClassName);
        }

        [TestMethod]
        public async Task GetRequestOfClassesEndpointWithId_ShouldReturnExpectedClassData()
        {
            // Arrange
            int id = 1;
            string url = "/api/classes/" + id;
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Class @class = await DeserializeResponse<Class>(response);
            Assert.AreEqual("Maths", @class.ClassName);
            Assert.AreEqual("Wilson's", @class.School);
            Assert.AreEqual("A", @class.Grade);
        }

        [TestMethod]
        public async Task PostRequestOfClassesToClassesEndpoint_ShouldAddTheClass()
        {
            // Arrange
            HttpClient client = _factory.CreateClient();

            var classToPost = new Class()
            {
                ClassName = "English"
            };
            string url = "/api/classes/";
            StringContent serializedClasse = SerializeObject(classToPost);

            // Act
            HttpResponseMessage response = await client.PostAsync(url, serializedClasse);

            // Assert
            Class classResponse = await DeserializeResponse<Class>(response);
            Assert.AreEqual(classToPost.ClassName, classResponse.ClassName);
            int expectedIdOfNewClass = 2;
            Assert.AreEqual(expectedIdOfNewClass, classResponse.ClassId);
        }
    }
}
