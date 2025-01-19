using Azure.Core;
using Azure.Identity;

namespace DEXRPG.Common.Configuration;

public class AzureConfiguration
{
    public TokenCredential Credential() =>

    #if DEBUG
        new DefaultAzureCredential();
    #else 
    
       new ManagedIdentityCredential("16575c00-1d5a-4ad2-8808-7a382f1ccf60")
    #endif
    
}