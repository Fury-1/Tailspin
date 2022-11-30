// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tailspin.Surveys.Common;
using Tailspin.Surveys.Data.DataModels;

namespace Tailspin.Surveys.Data.DataStore
{
    public interface ISurveyStore
    {
        Task<ICollection<Survey>> GetSurveysByOwnerAsync(Guid userId, int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
        Task<ICollection<Survey>> GetSurveysByContributorAsync(Guid userId, int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
        Task<Survey> GetSurveyAsync(Guid id);
        Task<Survey> UpdateSurveyAsync(Survey survey);
        Task<Survey> AddSurveyAsync(Survey survey);
        Task<Survey> DeleteSurveyAsync(Survey survey);
        Task<ICollection<Survey>> GetPublishedSurveysAsync(int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
        Task<ICollection<Survey>> GetPublishedSurveysByOwnerAsync(Guid userId, int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
        Task<Survey> PublishSurveyAsync(Guid id);
        Task<Survey> UnPublishSurveyAsync(Guid id);
        Task<ICollection<Survey>> GetPublishedSurveysByTenantAsync(Guid tenantId, int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
        Task<ICollection<Survey>> GetUnPublishedSurveysByTenantAsync(Guid tenantId, int pageIndex = 0, int pageSize = Constants.DefaultPageSize);
    }
}
