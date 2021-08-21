using System;
using System.Collections.Generic;
using Fluxor;
using soa.ui.Models.DTOs.Answers;

namespace soa.ui.Store.Answers
{
  public class AnswerFeature : Feature<AnswerState>
  {
    public override string GetName() => "Answer";

    protected override AnswerState GetInitialState() => new AnswerState(
      new List<AnswerDto>(), 
      "",
      true,
      new AnswerDto(), 
      new AnswerForCreationDto(), 
      new AnswerForModificationDto(), 
      Guid.Empty
    );
  }
}