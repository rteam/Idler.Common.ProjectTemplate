using BaseMicroService.Abstractions;
using BaseMicroService.Abstractions.Models;
using BaseMicroService.DomainService;
using Idler.Common.Core;
using Microsoft.AspNetCore.Mvc;

namespace BaseMicroService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    public TestController(ITestDomainService TestDomainService)
    {
        this.TestDomainService = TestDomainService;
    }

    private readonly ITestDomainService TestDomainService;

    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <returns></returns>
    [HttpPost("")]
    public ActionResult<APIReturnInfo<TestValue>> CreateTest(CreateTestModel modelInfo)
    {
        if (!this.ModelState.IsValid)
            return APIReturnInfo<TestValue>.Error("请按要求填写全部内容");

        return this.TestDomainService.CreateTest(modelInfo);
    }

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<APIReturnInfo<TestValue>> EditTest(Guid id, EditTestModel modelInfo)
    {
        if (!this.ModelState.IsValid)
            return APIReturnInfo<TestValue>.Error("请按要求填写全部内容");

        return this.TestDomainService.EditTest(id, modelInfo);
    }

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult<APIReturnInfo<TestValue>> RemoveTest(Guid id)
    {
        return this.TestDomainService.RemoveTest(id);
    }

    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<APIReturnInfo<TestValue>> SingleTest(Guid id)
    {
        return this.TestDomainService.SingleTest(id);
    }

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("All")]
    public ActionResult<APIReturnInfo<IList<TestValue>>> AllTest()
    {
        return this.TestDomainService.AllTest();
    }

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <returns></returns>
    [HttpGet("Paging")]
    public ActionResult<APIReturnInfo<ReturnPaging<TestValue>>> TestPaging(int pageNum = 1, int pageSize = 20)
    {
        return this.TestDomainService.TestPaging(pageNum, pageSize);
    }
}