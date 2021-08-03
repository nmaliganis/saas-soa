using soa.qa.contracts.Persons;

namespace soa.qa.contracts.V1
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