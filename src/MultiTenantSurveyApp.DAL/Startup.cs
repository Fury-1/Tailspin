﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// TODO: Remove. Will be unnecessary when bug #2357 fixed
// See https://github.com/aspnet/EntityFramework/issues/2357
// Also https://github.com/aspnet/EntityFramework/issues/2256

//

using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantSurveyApp.DAL.Configuration;
using MultiTenantSurveyApp.DAL.DataModels;
using System;
using Microsoft.Extensions.PlatformAbstractions;
#if DNX451
using MultiTenantSurveyApp.Configuration.Secrets;
#endif

public class Startup
{
    private ConfigurationOptions _configOptions = new ConfigurationOptions();
    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(appEnv.ApplicationBasePath)
            .AddJsonFile("../MultiTenantSurveyApp/config.json"); // path to your original configuration in Web project
        if (env.IsDevelopment())
        {
            // This reads the configuration keys from the secret store.
            // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            builder.AddUserSecrets();
        }
        //Uncomment the block of code below if your database connection string is in KeyVault and you want migrations to run using the connection string in KeyVault
        //#if DNX451
        //        var config = builder.Build();
        //        builder.AddKeyVaultSecrets(config["ClientId"],
        //            config["KeyVault:Name"],
        //            config["CertificateThumbprint"],
        //            false);
        //#endif
        builder.Build().Bind(_configOptions);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework()
            .AddSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configOptions.Data.SurveysConnectionString));
    }

    public void Configure() { }
}