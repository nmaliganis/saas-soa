using ms.person.api.Helpers.Services.Blocks.Persons.Contracts;

namespace ms.person.api.Helpers.Services.Blocks.Persons
{
  public interface IPersonsControllerDependencyBlock
  {
    ICreatePersonProcessor CreatePersonProcessor { get; }
    IInquiryPersonProcessor InquiryPersonProcessor { get; }
    IUpdatePersonProcessor UpdatePersonProcessor { get; }
    IInquiryAllPersonsProcessor InquiryAllPersonsProcessor { get; }
    IDeletePersonProcessor DeletePersonProcessor { get; }
  }
}