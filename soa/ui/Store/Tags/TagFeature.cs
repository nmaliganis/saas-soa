using System;
using System.Collections.Generic;
using Fluxor;
using soa.ui.Models.DTOs.Tags;

namespace soa.ui.Store.Tags
{
  public class TagFeature : Feature<TagState>
  {
    public override string GetName() => "Tag";

    protected override TagState GetInitialState() => new TagState(
      new List<TagDto>(), 
      "",
      true,
      new TagDto(), 
      new TagForCreationDto(), 
      new TagForModificationDto(), 
      Guid.Empty
    );
  }
}