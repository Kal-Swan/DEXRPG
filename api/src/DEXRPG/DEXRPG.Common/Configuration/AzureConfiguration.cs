using Azure.Core;
using Azure.Identity;

namespace DEXRPG.Common.Configuration;

public class AzureConfiguration
{
    public TokenCredential Credential() =>

#if DEBUG
        new DefaultAzureCredential();
    
    #else 
    
       new DefaultAzureCredential( new DefaultAzureCredentialOptions
       {
           ExcludeSharedTokenCacheCredential = true,
           ExcludeVisualStudioCredential = true,
           ExcludeAzureCliCredential = true,
       });
    #endif
    
}