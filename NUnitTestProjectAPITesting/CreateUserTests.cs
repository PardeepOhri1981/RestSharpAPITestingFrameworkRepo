using System.Threading.Tasks;
using RestSharp;
using RestSharpProject;
using RestSharpProject.Models.Requests;
using RestSharpProject.Models.Responses;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Net;
using System.Security.Permissions;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace NUnitTestProjectAPITesting;

public class CreateUserTests
{
    private CreateUserRequest createUserRequest;
    private CreateUserResponse createUserResponse;

    private UpdateUserRequest updateUserRequest;

    private RestResponse response;
    const string baseUrl = "https://api.restful-api.dev";
    const string name = "John Doe";
    const string job = "Software Developer";
    APIClient api;

    [SetUp]
    public void Setup()
    {
        this.api = new APIClient(baseUrl);
    }
    [TearDown]
    public void Cleanup()
    {
        api.Dispose();
    }

    [Test]
    public async Task CreateUser_ShouldReturnSuccess()
    {

        this.createUserRequest = new CreateUserRequest();
        createUserRequest.name = name;
        createUserRequest.data = new RestSharpProject.Models.Requests.Data { Color = "Black", Capacity = "64 GB" };
        var response = await api.CreateUser<CreateUserRequest>(createUserRequest);
        var statusCode = response.StatusCode;
        var code = (int)statusCode;
        Assert.That(code, Is.EqualTo(200));
    }

    [Test]
    public async Task UpdateUser_ShouldReturnSuccess()
    {

        this.updateUserRequest = new UpdateUserRequest();
        updateUserRequest.data = new RestSharpProject.Models.Requests.Data { Color = "Black", Capacity = "64 GB" };
        updateUserRequest.name = "Updated Name";
        var userId = "ff8081819782e69e01995abea5e51ca2";
        var response = await api.UpdateUser<UpdateUserRequest>(updateUserRequest, userId);
        var statusCode = response.StatusCode;
        var code = (int)statusCode;
        Assert.That(code, Is.EqualTo(200));
    }

    [Test]
    public async Task GetUser_ShouldReturnSuccess()
    {

        var response = await api.GetUser(id: "ff8081819782e69e01995abea5e51ca2");
        var statusCode = response.StatusCode;
        var code = (int)statusCode;
        Assert.That(code, Is.EqualTo(200));
        Assert.That(response.Content, Is.Not.Null);
        Assert.IsTrue(response.Content != null && response.Content.Contains("Updated Name"));
    }



    [Test]
    public async Task GetUsers_ShouldReturnSuccess()
    {

        var response = await api.GetListUsers();
        var statusCode = response.StatusCode;
        var code = (int)statusCode;
        Assert.That(code, Is.EqualTo(200));
        // Assert.That(response.Content, Is.Not.Null);
        //Assert.IsTrue(response.Content != null && response.Content.Contains("Updated Name"));
    }

    [Test]
    public async Task DeleteUsers_ShouldReturnSuccess()
    {

        var response = await api.DeleteUser("ff8081819782e69e019961b9143534c8");
        var statusCode = response.StatusCode;
        var code = (int)statusCode;
        Assert.That(code, Is.EqualTo(200));
        Assert.That(response.Content, Is.Not.Null);
         

    }
    

}