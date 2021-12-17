// This file is automatically generated by ABP framework to use MVC Controllers from CSharp
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Modeling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.ClientProxying;
using Volo.Docs.Projects;
using Volo.Docs.Documents;

// ReSharper disable once CheckNamespace
namespace Volo.Docs.Projects.ClientProxies;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IProjectAppService), typeof(DocsProjectClientProxy))]
public partial class DocsProjectClientProxy : ClientProxyBase<IProjectAppService>, IProjectAppService
{
    public virtual async Task<ListResultDto<ProjectDto>> GetListAsync()
    {
        return await RequestAsync<ListResultDto<ProjectDto>>(nameof(GetListAsync));
    }

    public virtual async Task<ProjectDto> GetAsync(string shortName)
    {
        return await RequestAsync<ProjectDto>(nameof(GetAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), shortName }
        });
    }

    public virtual async Task<string> GetDefaultLanguageCodeAsync(string shortName, string version)
    {
        return await RequestAsync<string>(nameof(GetDefaultLanguageCodeAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), shortName },
            { typeof(string), version }
        });
    }

    public virtual async Task<ListResultDto<VersionInfoDto>> GetVersionsAsync(string shortName)
    {
        return await RequestAsync<ListResultDto<VersionInfoDto>>(nameof(GetVersionsAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), shortName }
        });
    }

    public virtual async Task<LanguageConfig> GetLanguageListAsync(string shortName, string version)
    {
        return await RequestAsync<LanguageConfig>(nameof(GetLanguageListAsync), new ClientProxyRequestTypeValue
        {
            { typeof(string), shortName },
            { typeof(string), version }
        });
    }
}