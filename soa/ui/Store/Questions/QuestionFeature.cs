using System;
using System.Collections.Generic;
using Fluxor;
using soa.ui.Models.DTOs.Questions;

namespace soa.ui.Store.Questions
{
  public class QuestionFeature : Feature<QuestionState>
  {
    public override string GetName() => "Question";

    protected override QuestionState GetInitialState() => new QuestionState(
      new List<QuestionDto>(), 
      "",
      true,
      new QuestionDto(), 
      new QuestionForCreationDto(), 
      new QuestionForModificationDto(), 
      Guid.Empty
    );
  }
}