using CRTVUP.Unify.Common.ShortLink.Abstractions;
using CRTVUP.Unify.Common.ShortLink.Abstractions.Models;
using Idler.Common.Core;

namespace CRTVUP.Unify.Common.ShortLink.DomainService;

public interface ITestDomainService : IDomainService
{
    /// <summary>
    /// 创建测试信息
    /// </summary>
    /// <param name="modelInfo">要创建的内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<TestValue>> CreateTestAsync(CreateTestModel modelInfo, CancellationToken cancellationToken = default);

    /// <summary>
    /// 编辑测试信息
    /// </summary>
    /// <param name="id">要编辑的信息Id</param>
    /// <param name="modelInfo">要编辑的信息内容</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<TestValue>> EditTestAsync(Guid id, EditTestModel modelInfo, CancellationToken cancellationToken = default);

    /// <summary>
    /// 删除测试信息
    /// </summary>
    /// <param name="id">要删除信息Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<TestValue>> RemoveTestAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取指定测试信息
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<TestValue>> SingleTestAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 返回所有测试信息
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<IList<TestValue>>> AllTestAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 分页显示测试信息数据
    /// </summary>
    /// <param name="pageNum">第几页</param>
    /// <param name="pageSize">每页显示几条信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<APIReturnInfo<ReturnPaging<TestValue>>> TestPagingAsync(int pageNum = 1, int pageSize = 20, CancellationToken cancellationToken = default);
}
