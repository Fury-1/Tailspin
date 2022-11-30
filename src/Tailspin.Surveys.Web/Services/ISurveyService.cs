// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tailspin.Surveys.Data.DataModels;
using Tailspin.Surveys.Data.DTOs;
using Tailspin.Surveys.Web.Models;

namespace Tailspin.Surveys.Web.Services
{
    /// <summary>
    /// This interface defines the CRUD operations for <see cref="Survey"/>s.
    /// This interface also defines operations related to publishing <see cref="Survey"/>s
    /// and adding and processing <see cref="ContributorRequest"/>s.
    /// </summary>
    public interface ISurveyService
    {
        Task<SurveyDTO> GetSurveyAsync(Guid id);
        Task<UserSurveysDTO> GetSurveysForUserAsync(Guid userId);
        Task<TenantSurveysDTO> GetSurveysForTenantAsync(Guid tenantId);
        Task<SurveyDTO> CreateSurveyAsync(SurveyDTO survey);
        Task<SurveyDTO> UpdateSurveyAsync(SurveyDTO survey);
        Task<SurveyDTO> DeleteSurveyAsync(Guid id);
        Task<ContributorsDTO> GetSurveyContributorsAsync(Guid id);
        Task<ApiResult<IEnumerable<SurveyDTO>>> GetPublishedSurveysAsync();
        Task<SurveyDTO> PublishSurveyAsync(Guid id);
        Task<SurveyDTO> UnPublishSurveyAsync(Guid id);
        Task ProcessPendingContributorRequestsAsync();
        Task AddContributorRequestAsync(ContributorRequest contributorRequest);
    }
}