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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using Org.BouncyCastle.Security;



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
        readLinqConection();
        createUserRequest.data = new RestSharpProject.Models.Requests.Data { Color = "Black", Capacity = "64 GB" };
        var response = await api.CreateUser<CreateUserRequest>(createUserRequest);
        var statusCode = response.StatusCode;
        var code = (int)statusCode;

        Assert.That(code, Is.EqualTo(200));
    }

  /*   [Test]
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
        string str = ReadDataFromExcel().Result;
        Console.WriteLine(str);

        string value = ReadAppConfig();
        Console.WriteLine(value);
        var code = (int)statusCode;
      //  Assert.That(code, Is.EqualTo(200));
        Assert.That(response.Content, Is.Not.Null);
        Assert.That(str, Is.EqualTo("Pardeep"));
        Assert.That(value, Is.EqualTo("localhost:1433"));


    }
 */
    public async Task<string> ReadDataFromExcel()
    {
        string filePath = @"D:\RestSharpAPITesting\NUnitTestProjectAPITesting\TestData\TestData.xlsx";
        IWorkbook workbook = null;
        FileStream fileStream = null;
        String str = string.Empty;
        await using (fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            workbook = new XSSFWorkbook(fileStream);
        }

        ISheet sheet = workbook.GetSheetAt(0); // Assuming data is in the first sheet
        IRow row = sheet.GetRow(1); // Get the second row (index 1)
        if (row != null)
        {
            ICell cell = row.GetCell(0); // Get the first cell (index 0)
            if (cell != null)
            {
                return cell?.ToString() ?? string.Empty;
            }
        }
        return string.Empty;
    }
    private string ReadAppConfig()
    {
        string value = ConfigurationManager.AppSettings["DatabaseServer"] ?? string.Empty;
        Console.WriteLine(value);
        string port = ConfigurationManager.AppSettings["PortNumber"] ?? string.Empty;
        Console.WriteLine(port);
        return (value + ":" + port);

    }
    private void readLinqConection()
    {
        int[] numbers = { 1, 20, 30, 4, 5 };
        var num = from i in numbers where i > 10 select i;
        foreach (var n in num)
        {
            Console.WriteLine(n);
        }   
    }
}