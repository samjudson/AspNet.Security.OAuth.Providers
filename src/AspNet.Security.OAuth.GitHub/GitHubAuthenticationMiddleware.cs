﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Framework.Internal;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.WebEncoders;

namespace AspNet.Security.OAuth.GitHub {
    public class GitHubAuthenticationMiddleware : OAuthMiddleware<GitHubAuthenticationOptions> {
        public GitHubAuthenticationMiddleware(
            [NotNull] RequestDelegate next,
            [NotNull] IDataProtectionProvider dataProtectionProvider,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IUrlEncoder encoder,
            [NotNull] IOptions<SharedAuthenticationOptions> externalOptions,
            [NotNull] IOptions<GitHubAuthenticationOptions> options,
            ConfigureOptions<GitHubAuthenticationOptions> configureOptions = null)
            : base(next, dataProtectionProvider, loggerFactory,
                   encoder, externalOptions, options, configureOptions) {
        }

        protected override AuthenticationHandler<GitHubAuthenticationOptions> CreateHandler() {
            return new GitHubAuthenticationHandler(Backchannel);
        }
    }
}
