using CRTVUP.Unify.Common.ShortLink.Abstractions;
using CRTVUP.Unify.Common.ShortLink.Abstractions.Models;
using CRTVUP.Unify.Common.ShortLink.DomainService;
using Idler.Common.Core;
using Microsoft.AspNetCore.Mvc;

namespace CRTVUP.Unify.Common.ShortLink.API.Controllers;

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
    public async Task<ActionResult<APIReturnInfo<TestValue>>> CreateTest(CreateTestModel modelInfo)
    {
        if (!this.ModelState.IsValid)
            return APIReturnInfo<TestValue>.Error("请按要求填写全部内容");

        return await this.TestDomainService.CreateTestAsync(modelInfo, this.HttpContext.RequestAborted);
    }

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<APIReturnInfo<TestValue>>> EditTest(Guid id, EditTestModel modelInfo)
    {
        if (!this.ModelState.IsValid)
            return APIReturnInfo<TestValue>.Error("请按要求填写全部内容");

        return await this.TestDomainService.EditTestAsync(id, modelInfo, this.HttpContext.RequestAborted);
    }

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<APIReturnInfo<TestValue>>> RemoveTest(Guid id)
    {
        return await this.TestDomainService.RemoveTestAsync(id, this.HttpContext.RequestAborted);
    }

    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<APIReturnInfo<TestValue>>> SingleTest(Guid id)
    {
        return await this.TestDomainService.SingleTestAsync(id, this.HttpContext.RequestAborted);
    }

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("All")]
    public async Task<ActionResult<APIReturnInfo<IList<TestValue>>>> AllTest()
    {
        return await this.TestDomainService.AllTestAsync(this.HttpContext.RequestAborted);
    }

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <returns></returns>
    [HttpGet("Paging")]
    public async Task<ActionResult<APIReturnInfo<ReturnPaging<TestValue>>>> TestPaging(int pageNum = 1, int pageSize = 20)
    {
        return await this.TestDomainService.TestPagingAsync(pageNum, pageSize, this.HttpContext.RequestAborted);
    }
}
