using soa.qa.contracts.Persons;
using soa.qa.contracts.V1;

namespace soa.services.V1
{
    public class PersonsControllerDependencyBlock : IPersonsControllerDependencyBlock
    {
        public PersonsControllerDependencyBlock(ICreatePersonProcessor createPersonProcessor,
                                                        IInquiryPersonProcessor inquiryPersonProcessor,
                                                        IUpdatePersonProcessor updatePersonProcessor,
                                                        IInquiryAllPersonsProcessor allPersonProcessor,
                                                        IDeletePersonProcessor deletePersonProcessor)

        {
            CreatePersonProcessor = createPersonProcessor;
            InquiryPersonProcessor = inquiryPersonProcessor;
            UpdatePersonProcessor = updatePersonProcessor;
            InquiryAllPersonsProcessor = allPersonProcessor;
            DeletePersonProcessor = deletePersonProcessor;
        }

        public ICreatePersonProcessor CreatePersonProcessor { get; private set; }
        public IInquiryPersonProcessor InquiryPersonProcessor { get; private set; }
        public IUpdatePersonProcessor UpdatePersonProcessor { get; private set; }
        public IInquiryAllPersonsProcessor InquiryAllPersonsProcessor { get; private set; }
        public IDeletePersonProcessor DeletePersonProcessor { get; private set; }
    }
}