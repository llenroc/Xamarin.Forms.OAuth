﻿namespace Bigs.OAuth.Providers
{
    public sealed class AmazonOAuthProvider : OAuthProvider
    {
        internal AmazonOAuthProvider(string clientId, string redirectUrl, params string[] scopes)
            : base(new OAuthProviderDefinition(
                "Amazon",
                "https://www.amazon.com/ap/oa",
                null,
                "https://api.amazon.com/user/profile",
                clientId,
                null,
                redirectUrl,
                scopes)
            {
                MandatoryScopes = new[] { "profile" },
                GraphIdProperty = "user_id",
            })
        { }
    }
}
