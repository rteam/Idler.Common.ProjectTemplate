using BaseMicroService.Abstractions;
using BaseMicroService.Abstractions.Models;
using Idler.Common.Core;
using WebApiClientCore.Attributes;
namespace BaseMicroService.Implement;

public interface ITestAPI
{
    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <returns></returns>
    [HttpPost("Test")]
    Task<APIReturnInfo<TestValue>> CreateTest(CreateTestModel modelInfo);

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <returns></returns>
    [HttpPut("Test/{id}")]
    Task<APIReturnInfo<TestValue>> EditTest(Guid id, EditTestModel modelInfo);

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <returns></returns>
    [HttpDelete("Test/{id}")]
    Task<APIReturnInfo<TestValue>> RemoveTest(Guid id);

    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns></returns>
    [HttpGet("Test/{id}")]
    Task<APIReturnInfo<TestValue>> SingleTest(Guid id);

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <returns></returns>
    [HttpGet("Test/All")]
    Task<APIReturnInfo<IList<TestValue>>> AllTest();

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <returns></returns>
    [HttpGet("Test/Paging")]
    Task<APIReturnInfo<ReturnPaging<TestValue>>> TestPaging(int pageNum = 1, int pageSize = 20);
}