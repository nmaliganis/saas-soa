﻿using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Questions;

namespace soa.contracts.Questions
{
    public interface IInquiryQuestionProcessor
    {
        Task<QuestionUiModel> GetQuestionByIdAsync(int id);
        Task<QuestionUiModel> GetQuestionByTitleAsync(string title);
    }
}